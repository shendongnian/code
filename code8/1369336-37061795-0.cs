    [HttpGet]
    public ActionResult GetMyList()
    {
        List<object> list = getList();
        return Json(list, JsonRequestBehavior.AllowGet);
    }
