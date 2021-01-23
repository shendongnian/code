    string filename = "file path";
    Response.ContentType = "application/zip";
    Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
    string str = Server.MapPath("~/FolderPath/" + filename);
    Response.TransmitFile(Server.MapPath("~/FolderPath/" + filename));
    Response.End();
