     void download_Click(object sender, EventArgs e)
    {
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=help.pdf");
        Response.TransmitFile(Server.MapPath("~/pdf/catalog.pdf"));
        Response.End();
    }
