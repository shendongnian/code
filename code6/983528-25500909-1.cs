    protected void ExportToXLS(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Notifications.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter tw = new HtmlTextWriter(sw);
            repeaterID.DataSource = Session["SomeDataFromSession"] as List<SomeObject>;
            repeaterID.DataBind();
            rptNotifications.RenderControl(tw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }
