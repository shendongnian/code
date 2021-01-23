    public JsonResult StudList()
    {
        string SQL = "select id, name, div_code, block, from students where ....."; //see the below model 
        var con = DB.GetConnection();
        con.Open();
        OracleDataAdapter oraAdapt = new OracleDataAdapter(SQL, con);
        DataTable dt = new DataTable();
        oraAdapt.Fill(dt);
        con.Close();
        con.Dispose();
        List<GetStudentSearchModel> dtList = dt.AsEnumerable()
            .Select(row => new GetStudentSearchModel
            {
                id = row["id"],
                name = row["name"],
                div_code = row["div_code"],
                //...
            }).ToList(); 
        return Json(dtList, JsonRequestBehavior.AllowGet); 
    }
