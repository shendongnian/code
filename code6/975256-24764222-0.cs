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
        var serializer = new JavaScriptSerializer();
        var json = serializer.Serialize(settings);
        var settingsVm = new SettingsViewModel
        {
            SettingsJson = json,
            AngularModuleName = angularModuleName
        };
        Response.ContentType = "text/javascript";
        return View(settingsVm);
    }
