    string path = @"E:\newfolder";
    if (!Directory.Exists(path))
    {
       DirectoryInfo di = Directory.CreateDirectory(path);
       if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
       {
         di.Attributes = FileAttributes.System|FileAttributes.Hidden;
       }
    }
