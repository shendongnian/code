    protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
               //updateCountDownloaded(e.CommandArgument.ToString());
                updateCountDownloaded("1");
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Files/") + e.CommandArgument.ToString());
                Response.End();
    
            }        
        }
