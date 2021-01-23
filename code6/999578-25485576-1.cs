    protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
       if (e.CommandName == "SelectDownload")
       {
          Response.Clear();
          Response.ContentType = "application/octet-stream";
          Response.AppendHeader("Content-Disposition", "filename=" + e.CommandArgument);
          Response.TransmitFile(Server.MapPath("~/PoPDF/") + e.CommandArgument);
            //Response.Flush();
                 Response.End();
       }
    }
