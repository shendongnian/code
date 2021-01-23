    [HttpPost]
    public ActionResult Index([Bind(Include="ITXT_USER_ID ,TXT_USER_PWD ")]tbl_userMetaData userMetaData)
    {
        if (ModelState.IsValid)
        {
            RedirectToAction("Index", new { Area = "Admin" });
        }
        return View();
    
    }
