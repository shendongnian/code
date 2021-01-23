    string path = @"E:\newfolder";
    if (!Directory.Exists(path))
    {
       DirectoryInfo di = Directory.CreateDirectory(path);
       if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
       {
         di.Attributes = FileAttributes.System|FileAttributes.Hidden;//set attributes to System and Hidden.
       }
    }
    else
    {
       //set attributes if the directory is already exists.
       DirectoryInfo di = new DirectoryInfo(path);
       if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
       {
         di.Attributes = FileAttributes.Hidden;
       }
    }
