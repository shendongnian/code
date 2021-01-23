    protected void BindData()
    {
        try
        {
            filePaths = Directory.GetFiles(@"C:\PDFGenerate");
            files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), File.GetLastWriteTime(filePath).ToString()));
            }
            Session["fileData"] = files;
            Sort(files, SortDirection.Descending);
        }
        catch (Exception ce)
        {
        }
        //MessageBox.Show(files.Count() + ""); // displays the count for the files being displayed
    }
