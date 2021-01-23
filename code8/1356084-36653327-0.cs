    DirectoryInfo dir = new DirectoryInfo(@"../Debug/");
    FileInfo[] files = dir.GetFiles("*.txt");
    Dictionary<FileInfo, DateTime> filesWithDueDate = new Dictionary<FileInfo, DateTime>();
    
    foreach (FileInfo file in files)
    {
        string dueDate = File.ReadAllText(file.FullName);
    
        Regex regex = new Regex(@"\d{2}/\d{2}/\d{4}");
        Match mat = regex.Match(dueDate);
    
        DateTime duedate = Convert.ToDateTime(mat.ToString());
    
        filesWithDueDate.Add(file, duedate);
    }
    
    var sortedFiles = filesWithDueDate.OrderBy(a => a.Value).Select(b => b.Key.Name).ToArray();
    
    listBox1.Items.AddRange(sortedFiles);
