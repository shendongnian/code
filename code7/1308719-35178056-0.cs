    //Create a dummy GridView
    GridView GridView1 = new GridView();
    GridView1.AllowPaging = false;
    GridView1.DataSource = dsData.Tables[1];//Assign datatable to gridview source
    GridView1.DataBind();
 
    Response.Clear();
    Response.Buffer = true;
    Response.AddHeader("content-disposition",
        "attachment;filename=DataTable.doc");
    Response.Charset = "";
    Response.ContentType = "application/vnd.ms-word ";
    StringWriter sw = new StringWriter();
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    GridView1.RenderControl(hw);
    Response.Output.Write(sw.ToString());
    Response.Flush();
    Response.End();
