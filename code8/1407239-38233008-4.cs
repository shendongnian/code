    // Change @"C:\" to your upload directory
    string[] files = Directory.GetFiles(@"C:\");
    
    var oldestFile = files.OrderBy(path => File.GetCreationTime(path)).FirstOrDefault();
    if (oldestFile != null)
    {
        var oldestDate = File.GetCreationTime(oldestFile);
    
        if (DateTime.Now.Subtract(oldestDate).TotalMinutes > 30)
        {
            // Do Something
        }
    }
