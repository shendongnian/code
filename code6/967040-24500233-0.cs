    Response.Clear();
    Response.AddHeader("content-disposition", "attachment; filename=UsersReport.xls");
    Response.ContentType = "application/ms-excel";
    Response.ContentEncoding = System.Text.Encoding.Unicode;
    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
    
    StringWriter sw = new StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    grid.RenderControl(htw);
    Response.Write(sw.ToString());
    Response.End();
