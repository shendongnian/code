    protected void DownloadFile(object sender, EventArgs e)
      {
        string filePath = (sender as LinkButton).CommandArgument;
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" +        Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        Response.End();
      }
