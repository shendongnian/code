    StorageFolder testFolder;
    public MyClass()
    {
        var removableDevices = KnownFolders.RemovableDevices; 
        var externalDrives = await removableDevices.GetFoldersAsync(); 
        var drive0 = externalDrives[0];
        testFolder = await drive0.CreateFolderAsync("test");
        await testFolder.CreateFileAsync("test.jpg");
    }
