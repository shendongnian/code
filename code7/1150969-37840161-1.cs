    string folderPath = Environment.ExternalStorageDirectory.AbsolutePath; //Andriod     
 
       public async Task PCLGenaratePdf(string path)
        {
            IFolder rootFolder = await FileSystem.Current.GetFolderFromPathAsync(path);
            IFolder folder = await rootFolder.CreateFolderAsync("folder", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("file.pdf", CreationCollisionOption.ReplaceExisting);
        }
