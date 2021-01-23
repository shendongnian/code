    string path = @"C:\Projects\";
    string criteria = "*" + textBox1.Text + "*";
    
    string[] dir = Directory.GetDirectories(path, criteria);
    foreach (string directory in dir)
    {
        string newCriteria = "Photos";
        string[] subDir = Directory.GetDirectories(directory, newCriteria);
        foreach (string subDirectory in subDir)
        {
            System.Diagnostics.Process.Start(subDirectory);
        }
    }
