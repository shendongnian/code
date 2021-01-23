    public async Task<HttpResponseMessage> SomeMethod()
    {
       try
       {
           await login...;
           await doSomething....
           await oneMoreAsyncCall...
           return Request.CreateResponse(HttpStatusCode.OK, someData);
       }
       catch {}
    
       return Request.CreateResponse(HttpStatusCode.SeeOther);
    }
