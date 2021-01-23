    protected async void TakePictureAndUpload()
    {
        var ui = new CameraCaptureUI();
        var file = await ui.CaptureFileAsync(CameraCaptureUIMode.Photo);
        if (file != null)
        {    
            byte[] myPicArray = await GetPhotoBytesAsync(file);
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://yourdomainname.com");
    
            MultipartFormDataContent form = new MultipartFormDataContent();
            HttpContent content = new ByteArrayContent(myPicArray);
            form.Add(content, "media", "filename.jpg");
            content = new StringContent("my-username");
            form.Add(content, "username");
            HttpResponseMessage response = await httpClient.PostAsync("directory/my-site.php", form);
         }
    }
    public async Task<byte[]> GetPhotoBytesAsync(StorageFile file)
    {
        IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read);
        var reader = new Windows.Storage.Streams.DataReader(fileStream.GetInputStreamAt(0));
        await reader.LoadAsync((uint)fileStream.Size);
        byte[] pixels = new byte[fileStream.Size];
        reader.ReadBytes(pixels);
        return pixels;
    }
