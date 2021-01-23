    [HttpGet]
    public ActionResult YourActionName()
    {
        var schooList = schGateway.SelectAll();
    
        //Use only what you need
        var result = new {
          locations = //schooList.attribute ,
          otherAttribute = //schooList.otherAttribute 
        };
    
        return Json(result, JsonRequestBehavior.AllowGet);
    }
