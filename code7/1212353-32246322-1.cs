    public ActionResult AjaxDoSomething(string vmop)
    {
        var jss = new JavaScriptSerializer();
        try
        {
            var parameter = jss.Deserialize<ViewMethodOfPayment []>(vmop);
            //Do something with this data and return the desired result
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        catch
        {
            return null;
        }
    }
