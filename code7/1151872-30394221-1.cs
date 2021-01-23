    [HttpPost]
    public ActionResult ProtocolAjaxHandler(object _param)
    {
        System.Threading.Thread.Sleep(15000);
        return Json(null);
    }
