    private async void SaveFileExecute()
    {
        var fileNameTab = FileName.Split('.');
        var extension = fileNameTab[1];
        var fileName = fileNameTab[0];
        var savePicker = new FileSavePicker
        {
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
            SuggestedFileName = fileName
        };
        savePicker.FileTypeChoices.Add(extension, new List<string> { "." + extension });
        var saveFile = await savePicker.PickSaveFileAsync();
        if (saveFile != null)
        {
            using (var fileStream = await saveFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var outputStream = fileStream.GetOutputStreamAt(0))
                {
                    using (var dataWriter = new DataWriter(outputStream))
                    {
                        dataWriter.WriteBytes(SelectedFile.Data);
                        await dataWriter.StoreAsync();
                        dataWriter.DetachStream();
                    }
                    await outputStream.FlushAsync();
                }
            }
        }
    }
