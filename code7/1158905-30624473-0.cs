    FileOpenPicker picker = new FileOpenPicker();
    picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
    picker.ViewMode = PickerViewMode.Thumbnail;
    // Filter to include a sample subset of file types.
    picker.FileTypeFilter.Clear();
    picker.FileTypeFilter.Add(".bmp");
    picker.FileTypeFilter.Add(".png");
    picker.FileTypeFilter.Add(".jpeg");
    picker.FileTypeFilter.Add(".jpg");
    // Open the file picker.
    StorageFile path = await picker.PickSingleFileAsync();
    if (path != null)
    {
         string url = "https://YourSite.com/Subsite/";
         HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
         client.BaseAddress = new System.Uri(url);
         client.DefaultRequestHeaders.Clear();
         client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
         client.DefaultRequestHeaders.Add("X-RequestDigest", digest);
         client.DefaultRequestHeaders.Add("X-HTTP-Method", "POST");
         client.DefaultRequestHeaders.Add("binaryStringRequestBody", "true");
         IRandomAccessStream fileStream = await path.OpenAsync(FileAccessMode.Read);
         var reader = new DataReader(fileStream.GetInputStreamAt(0));
         await reader.LoadAsync((uint)fileStream.Size);
         Byte[] content = new byte[fileStream.Size];
         reader.ReadBytes(content);
         ByteArrayContent file = new ByteArrayContent(content);
         HttpResponseMessage response = await client.PostAsync("_api/web/lists/getByTitle(@TargetLibrary)/RootFolder/Files/add(url=@TargetFileName,overwrite='true')?@TargetLibrary='Project Photos'&@TargetFileName='TestUpload.jpg'", file);
         response.EnsureSuccessStatusCode();
         if (response.IsSuccessStatusCode)
         { }
     }
