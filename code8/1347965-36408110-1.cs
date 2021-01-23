    [HttpGet]
    public JsonResult GetPhones()
    {
        return Json(new TestPhoneService().GetTestData());
    }
