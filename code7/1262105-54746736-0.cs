         [HttpGet]
          public HttpResponseMessage GetJson()
          {
            var result = new List<string>();
            for (int i = 0; i < 50; i++)
                result.Add("Hello World");
          
           return Request.CreateResponse(HttpStatusCode.OK, result, new 
            MediaTypeHeaderValue("application/json"));
        }
