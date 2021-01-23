    namespace MRNInput.Controllers
    {
        public class AppointmentController : ApiController
        {
            [HttpPost, Route("api/Appointments/GetMissingKeys")]
            public IHttpActionResult GetMissingAppointmentKeys([FromBody]string MRNList)
            {
                return Ok();
            }
        }
    }
    
    $.ajax({
       type: 'POST',
       url: '/api/Appointments/GetMissingKeys',
       data:  $('#mrnList').val() //ensure you have a value here,
       datatype: "json" //<-- note the additional property                     
    })
