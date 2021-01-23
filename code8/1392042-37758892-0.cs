    public ActionResult Search(string search) {
        var model = Productdb.Database.Query<ReturnObject>(
            "ProcedureName", 
            new System.Data.SqlClient.SqlParameter("@SearchText", search)
            ).ToList();
         return View("Search", model);
    }
