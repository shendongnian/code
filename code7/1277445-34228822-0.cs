    protected void BindGrid()
    {
      string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/"));
      List<ListItem> files = new List<ListItem>();
      foreach (string filePath in filePaths)
      { 
        int dotPos = filePath.IndexOf('.');
        String sansExt = filePath.Substring(1, dotPos);
        if (!files.Contains[sansExt]
        {
            files.Add(new ListItem(Path.GetFileName(filePath), filePath));
        }
      }
    GridView1.DataSource = files;
    GridView1.DataBind();
