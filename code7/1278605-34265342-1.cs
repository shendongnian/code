    private void LoadImages()
    {
       _selectedImageList.Clear();
    
       DirectoryInfo aSnapshotTempDir = new DirectoryInfo(@"..\..\Images");
    
       foreach (FileInfo aFile in aSnapshotTempDir.GetFiles("*.jpg"))
       {
           Uri uri = new Uri(aFile.FullName);
           _selectedImageList.Add( new BitmapImage( uri ) );
       }
    }
