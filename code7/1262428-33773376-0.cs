    [HttpPost]
        public HttpResponseMessage Put(UserInfo userInfo) {
         if(ModelState.IsValid)
        {
         // your code
        return Request.CreateResponse(HttpStatusCode.OK);
        }
        else
        {
        return Request.CreateResponse(HttpStatusCode.BadRequest, new { msg = "invalid data" });
        }
        }
