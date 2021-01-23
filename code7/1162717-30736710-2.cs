    string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileName(filePath);
            files.Add(new ListItem(fileName, "~/Images/" + fileName));
        }
        GridView2.DataSource = files;
        GridView2.DataBind();
