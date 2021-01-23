    public HttpResponseMessage Register()
    {
       //DO something as you want 
        var newUrl = this.Url.Link("Default", new { Controller = "Account", 
                                                                       Action = "Register" });
        return Request.CreateResponse(HttpStatusCode.OK,
                                                  new {Success = true, RedirectUrl = newUrl});
    }
