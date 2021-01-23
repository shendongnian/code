    private void buttonNext_Click(object sender, EventArgs e)
    {
        int dummy;
        var currentFile = Directory.GetFiles(@"D:\", "*.txt", SearchOption.TopDirectoryOnly)
                                .Select(x => new { Path = x, NameOnly = Path.GetFileNameWithoutExtension(x) })
                                .Where(x => Int32.TryParse(x.NameOnly, out dummy))
                                .OrderBy(x => Int32.Parse(x.NameOnly))
                                .Where(x => Int32.Parse(x.NameOnly) > lastFileNumber)
                                .FirstOrDefault();
    
        if (currentFile != null)
        {
            lastFileNumber = Int32.Parse(currentFile.NameOnly);
    
            string currentFileContent = File.ReadAllText(currentFile.Path);
        }
        else
        {
           // reached the end, do something or show message
        }
    }
