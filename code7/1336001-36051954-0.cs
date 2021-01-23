    Response.Clear();
    Response.Buffer = true;
    Response.AddHeader("content-disposition",
     "attachment;filename=GridViewExport.xls");
    Response.Charset = "";
    Response.ContentType = "application/vnd.ms-excel";
    
    StringWriter sw = new StringWriter();
    HtmlTextWriter hw = new HtmlTextWriter(sw);
    GridView1.AllowPaging = false;
    GridView1.DataBind();
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
        GridViewRow row = GridView1.Rows[i];
        //Apply text style to each Row
        row.Attributes.Add("class", "textmode");
    }
    GridView1.RenderControl(hw);
 
    //style to format numbers to string
    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
    Response.Write(style);
    Response.Output.Write(sw.ToString());
    Response.Flush();
    Response.End();
