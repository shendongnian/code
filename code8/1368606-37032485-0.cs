    private List<FileListItem> myFileListItem;   
    public List<FileListItem> MyFileListItem 
    {
        get 
        {  
           if (myFileListItem == null) 
           { 
               myFileLinstItem = new List<FileListItem>();
               foreach (FilePaths filePath in directoryPath.GetFilePaths())
               {
                  myFileListItem.Add(GetFileListViewItem(filePath));
                  // change GetFileListViewItem to return a FileListItem
               }
           }  
           return myFileListItem;
        }
     }
