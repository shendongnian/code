    string folderPath = Environment.ExternalStorageDirectory.AbsolutePath; //Android     
 
       public async Task PCLGenaratePdf(string folderPath )
        {
            IFolder rootFolder = await FileSystem.Current.GetFolderFromPathAsync(folderPath );
            IFolder folder = await rootFolder.CreateFolderAsync("folder", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("file.pdf", CreationCollisionOption.ReplaceExisting);
        }
