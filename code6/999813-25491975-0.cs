    public ActionResult Index( string brand ) {
        if (string.IsNullOrEmpty(brand)) {
            brand = "TLC"; 
        }
        Session["brand"] = brand;
        return View();
    }
