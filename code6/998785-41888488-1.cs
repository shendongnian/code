    [HttpPost]
    public ActionResult RunService(string operationType)
    {
        // Codes
        Response.StatusCode = 200;
        return Json(JsonRequestBehavior.AllowGet);
    }
