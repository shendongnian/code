    private List<FileListItem> myFileListItems;   
    public List<FileListItem> MyFileListItems 
    {
        get 
        {  
           if (myFileListItems == null) 
           { 
               myFileLinstItems = new List<FileListItem>();
               foreach (FilePaths filePath in directoryPath.GetFilePaths())
               {
                   string ext = GetExtension(filePath.GetPath());
                   if (String.IsNullOrEmpty(ext)
                      ext = "Unknown";
                   else 
                      ext = ext.ToUpper().Substring(1) + " File";
                   myFileListItems.Add(new FileListItem
                                       {
                                          Name = GetFileNameWithoutExtension(filePath.GetPath());,
                                          Type = ext
                                       });
               }
           }  
           return myFileListItems;
        }
     }
