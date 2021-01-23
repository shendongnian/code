    protected void gridContributions_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
            string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            string fileNameWithGUID = commandArgs[0];
            string fileNameWithoutGUID = commandArgs[1];
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment; Filename=" + fileNameWithoutGUID + ".pdf");
            Response.TransmitFile(Server.MapPath("~/Match/Reciepts/") + fileNameWithGUID);
            Response.End();
        }
    } 
