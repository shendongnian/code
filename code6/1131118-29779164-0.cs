    // Get the folder.
    StorageFolder camera = Windows.Storage.ApplicationData.Current.CameraRoll;
    if (local != null)
    {
        // Get the file.
        var file = await camera.OpenStreamForReadAsync("WP_20150421_001.jpg");
        // Read the data.
        using (StreamReader streamReader = new StreamReader(file))
        {
            //streamReader.ReadToEnd();
        }
    }
