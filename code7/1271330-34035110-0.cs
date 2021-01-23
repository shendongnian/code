    public ActionResult ExportToExcel()
    {
        var products = new System.Data.DataTable();
        products.Columns.Add("code", typeof(int));
        products.Columns.Add("description", typeof(string));
        // you can add your columns here as many you want
    
        var a = db.MSTs.Where(x => x.S2 == "ASSETS").FirstOrDefault();
        var l = db.MSTs.Where(x => x.S2 == "LIABILITIES").FirstOrDefault();
        
        // in this way you can get data from database if you are using.. or u may use any other way to seed your file as per your need
    
        products.Rows.Add(a.S1, a.S2, a.S39, a.S40);
        products.Rows.Add(l.S1, l.S2, l.S39, l.S40);
        
        // seeding the rows
    
        var grid = new GridView();
        grid.DataSource = products;
        grid.DataBind();
        Response.ClearContent();
        Response.Buffer = true;
        
        Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AppendHeader("content-disposition", "attachment; filename=filename.xlsx");
    
        Response.Charset = "";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grid.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    
        return View("MyView");
    }
