using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeAttendanceSystem.Models;
using EmployeeAttendanceSystem.Services.AttendanceServices;

namespace EmployeeAttendanceSystem.Controllers
{
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }


        [HttpGet]
        [Route("api/[controller]/GetAttendances")]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
        {
            return (await _attendanceService.GetAttendances()).ToList();
        }

        [HttpGet]
        [Route("api/[controller]/GetAttendance/{id}")]
        public async Task<ActionResult<Attendance>> GetAttendanceById(string id)
        {
             var result = await _attendanceService.GetAttendanceById(id);
             return result;
        }

        [HttpPost]
        [Route("api/[controller]/CreateAttendance")]
        public async Task<ActionResult<Attendance>> CreateAttendance(Attendance attendanceObj)
        {
            var createAuthor = await _attendanceService.CreateAttendance(attendanceObj);  
            return createAuthor;
        }


        [HttpPut]
        [Route("api/[controller]/UpdateAttendance")]
        public async Task<ActionResult<Attendance>> UpdateAttendance(Attendance attendanceObj)
        {
            var attendanceUpdate = await _attendanceService.UpdateAttendance(attendanceObj);
            return attendanceUpdate;
        }


        [HttpDelete]
        [Route("api/[controller]/DeleteAttendance/{id}")]
        public async Task<ActionResult<Attendance>> DeleteAttendance(string id)
        {
           
            var attendanceDelete = await _attendanceService.DeleteAttendance(id);
            return attendanceDelete;
        }


    }
}
