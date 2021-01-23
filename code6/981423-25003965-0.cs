    public ActionResult ExportToExcel()
    {
        var products = new System.Data.DataTable("test");
        products.Columns.Add("col1", typeof(int));
        products.Columns.Add("col2", typeof(string));
        products.Rows.Add(1, "product 1");
        products.Rows.Add(2, "product 2");
        products.Rows.Add(3, "product 3");
        products.Rows.Add(4, "product 4");
        products.Rows.Add(5, "product 5");
        products.Rows.Add(6, "product 6");
        products.Rows.Add(7, "product 7");
        var grid = new GridView();
        grid.DataSource = products;
        grid.DataBind();
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
        Response.ContentType = "application/ms-excel";
        Response.Charset = "";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        grid.RenderControl(htw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
        return View("MyView");
    }
