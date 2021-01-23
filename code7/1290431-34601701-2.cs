    var dataWriter = new DataWriter(File.OpenRead("..."));
    using (dataWriter)
    {
        dataWriter.WriteBytes(message.MessageBuffer);
    }
    await dataWriter.StoreAsync();
