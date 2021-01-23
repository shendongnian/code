    public ActionResult ServerError()
    {
      HttpException ex = Server.GetLastError() as HttpException; 
      var model = GetModel(ex);
      Response.StatusCode = (int)HttpStatusCode.InternalServerError;
      Response.Status = "500 Internal Server Error";
      return View(model);
    }
