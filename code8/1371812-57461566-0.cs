    public ActionResult SomeMethod()
    {
        try
        {
            // ...
            // doing something here...
            // ...
    
            // success:
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new { responseText = "OK" });
        }
        catch
        {
            // error:
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { responseText = "ERROR" });
        }
    }
