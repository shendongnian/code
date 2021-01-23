    LiveConnectClient connectClient = new LiveConnectClient(this.Session);
    using (Stream stream = await InputFile.OpenStreamForReadAsync())
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            LiveOperationResult _opResult = await connectClient.PutAsync(Awesome2FolderID + "/files/" + OneDriveFilename, reader.ReadToEnd());
        }
    }
