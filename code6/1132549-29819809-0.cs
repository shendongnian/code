    use the System.IO.DirectoryInfo class:
    
    var di = new DirectoryInfo(folderName);
    
    if(di.Exists())
    {
      if (di.Attributes.HasFlag(FileAttributes.ReadOnly))
      {
        //IsReadOnly...
      }
