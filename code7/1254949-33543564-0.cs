    private void downloadAnImage(string strImage)
    {
        Response.Clear();
        Response.ContentType = "image/jpg";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + strImage);
        Response.TransmitFile(strImage);
        Response.Flush();
        Response.End();
    }
