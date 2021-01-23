    HashSet<string> directories = new HashSet<string>();
    string[] allowableExtension = new [] {"jpg", "png"};
    foreach(var file in Directory.EnumerateFiles(sourceTextBox.Text,
                                                 "*", 
                                                 SearchOption.AllDirectories))
    {
        string extension = Path.GetExtension(file);
        if (allowableExtension.Contains(extension))
        {
            directories.Add(Path.GetDirectoryName(file));
        }
    }
