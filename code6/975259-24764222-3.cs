    using System.Web.Script.Serialization;
    // ...
    public ActionResult Settings(string angularModuleName = "myApp")
    {
        var settings = new 
        {
            uri1 = GetUri1(),
            uri2 = GetUri1()
            // ...
        };
        return Json(settings, JsonRequestBehavior.AllowGet);
    }
