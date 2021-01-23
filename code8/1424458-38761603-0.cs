    public void ExportToExcel()
    {
      DataGrid dgGrid = new DataGrid();
      dgGrid.DataSource = /*Give your data source here*/;
      dgGrid.DataBind();
      System.Web.HttpContext.Current.Response.ClearContent();
      System.Web.HttpContext.Current.Response.Buffer = true;
      System.Web.HttpContext.Current.Response.AddHeader("content-disposition",    string.Format("attachment; filename={0}", "Data Report.xls"));
      System.Web.HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
      System.Web.HttpContext.Current.Response.Charset = "";
      System.IO.StringWriter sw = new System.IO.StringWriter();
      HtmlTextWriter htw = new HtmlTextWriter(sw);
      dgGrid.RenderControl(htw);
      System.Web.HttpContext.Current.Response.Output.Write(sw.ToString());
      System.Web.HttpContext.Current.Response.Flush();
      System.Web.HttpContext.Current.Response.End();
    }
