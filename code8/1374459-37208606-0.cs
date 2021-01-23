    StringWriter sw = new StringWriter();
    HtmlTextWriter htw = new HtmlTextWriter(sw);
    // instantiate a datagrid
    DataGrid dg = new DataGrid();
    dg.DataSource = dataTable; //your dataTable
    dg.DataBind();
    dg.RenderControl(htw);
    divID.InnerHtml = sw.ToString();  
