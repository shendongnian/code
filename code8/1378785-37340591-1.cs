    MediaElement PlayMusic = new MediaElement();
    StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
    Folder = await Folder.GetFolderAsync("MyFolder");
    StorageFile sf = await Folder.GetFileAsync("MyFile.mp3");
    PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
    PlayMusic.Play();
