    protected void DownloadFile(object sender, EventArgs e)
    {
        try
        {
            string filePath = (sender as LinkButton).CommandArgument;
            System.Net.WebClient req = new System.Net.WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + Server.MapPath("~/YourFolder/" + filePath) + "\"");
            byte[] data = req.DownloadData(Server.MapPath("~/YourFolder/" + filePath));
            response.BinaryWrite(data);
            response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
