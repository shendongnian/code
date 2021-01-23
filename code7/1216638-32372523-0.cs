    public ActionResult Invoices(string JSonString)
    {
        //Add System.Web.Script.Serialization namespace on top of the page
        MyModel myModelObject = 
                   new JavaScriptSerializer().Deserialize<MyModel>(JSonString);
        //Use myModelObject, save to db, display message
        return View();
    }
