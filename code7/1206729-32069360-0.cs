    [HttpGet]
    public JsonResult  Get(int id)
    {
        var x = db.TESTS.ToList();
        var formatter = new JsonMediaTypeFormatter();
        return Json(formatter , JsonRequestBehavior.AllowGet);  
    }
