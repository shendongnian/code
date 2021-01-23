    [HttpGet]
    [Route("home/students")]
    public HttpResponseMessage GetStudents()
    {
           // Get students from Database
    
           // Create the response
            var response = Request.CreateResponse(HttpStatusCode.OK, studends);
        
            // Set headers for paging
            response.Headers.Add("X-Students-Total-Count", studends.Count());
           
           return response;
    }
