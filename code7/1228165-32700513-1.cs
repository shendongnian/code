        public class StaffController : ApiController //inherits ApiController 
        {
            [HttpPost] //add post attribute
            public HttpResponseMessage SaveStaff(StaffSaveRequest staffSaveRequest)
            {
                try
                {            
                    var result = StaffManager.Save(staffSaveRequest);//save in database using a method in data access layer
                    return Request.CreateResponse(HttpStatusCode.OK, result);//result the response back
                }
                catch (Exception ex)
                {
                   //log error
                }
            }
