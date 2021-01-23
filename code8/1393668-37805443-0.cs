    protected void ExporttoExcel(object sender, EventArgs args)
    {
        DataTable dt = GetValues();        
        var grid = new System.Web.UI.WebControls.GridView();
        grid.ShowHeaderWhenEmpty = true;        
        grid.DataSource = dt;
        
        grid.DataBind();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=Data.xls");
        Response.ContentType = "application/excel";
        StringWriter sw = new StringWriter();
        System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
        grid.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();               
    }
