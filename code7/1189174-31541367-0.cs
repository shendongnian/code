    protected JsonResult JsonError(Exception e)
    {
        Response.StatusCode = (int) System.Net.HttpStatusCode.InternalServerError;
        Response.StatusDescription = e.Message.Replace("\r\n", " | ");
        return Json(new {e.Message}, JsonRequestBehavior.AllowGet);
    }
