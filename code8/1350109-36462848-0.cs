    public async Task<ActionResult> index(int? page)
    {
        if (page == null)
        {
            page = 1;
            ViewBag.page = page;
        }
        else
        {
            ViewBag.page = page;
        }
        string Connectionstring = ConfigurationManager.ConnectionStrings["mycontext"].ConnectionString;
        using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
        {
            await sqlConnection.OpenAsync();
            var sqlM = @"SELECT * from threads order by activities desc";
            var resultM = await sqlConnection.QueryAsync<thread>(sqlM);
            return View(new homepage { panel = resultM });
        }
    }
