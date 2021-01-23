     public ActionResult YourControllerName(string Hdata,string abc, string abcd)
     {
        ViewBag.Hdata = Hdata;
        ViewBag.abc = abc;
        ViewBag.abcd= abcd;
        return PartialView();
     }
