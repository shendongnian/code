    StorageFolder _folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
    /*fails here FileNotFound*/
    StorageFile sourceCompressedFile = await _folder.GetFileAsync("archived.zip");
    
    StorageFolder folder = ApplicationData.Current.LocalFolder;
    
    // ZipFile.ExtractToDirectory(file.Path, folder.Path);
    
    using (ZipArchive archive = ZipFile.OpenRead(sourceCompressedFile.Path))
    {
        foreach (ZipArchiveEntry entry in archive.Entries)
        {
            if (entry.FullName.ToString() == "miao2.jpg")
            {
                entry.ExtractToFile(Path.Combine(folder.Path, entry.FullName));
            }
        }
    }
