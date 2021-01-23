     public ActionResult Index(string what, string where, int page = 1, string cn = "", string sv      = "", string ch = "", string deals = "", int brand = 0)
     {
        TempData["details"] = your_variable_with_details;
        return RedirectToAction("OtherAction");
     }
