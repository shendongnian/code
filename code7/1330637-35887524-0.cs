    [HttpGet]
    [ResponseType(typeof(IEnumerable<MyEntity>))]
    public IHttpActionResult Get()
    {
        //when ok
        return Ok(response); // response is your IEnumerable<MyEntity>
        //when error
        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.WhateverStatusCodeSuitable)
                {
                    ReasonPhrase = "your message"
                });
        
    }
