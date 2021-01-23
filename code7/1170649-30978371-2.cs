    private void SaveFileDetails()
    {
        string subDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Horse Monitoring Records");
        // create the folder hierarchy if not exists. does nothing if already there
        Directory.CreateDirectory(subDirectory);
        // each patient has individual file
        var filepath = Path.Combine(subDirectory,
            txtPatName.Text + "-" + txtOwnerName.Text + "-" + DateTime.Now.Date.ToString("yyyyMMdd") + ".txt");
        // creates the file if not exists
        using (var writer = new StreamWriter(filepath, append: true, encoding: Encoding.UTF8))
        {
            // write details
        }
    }
