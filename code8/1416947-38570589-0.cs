    public static async Task<bool> UploadFile(StorageFile file, string upload_url)
    {
        try
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            var content = new MultipartFormDataContent();
            if (file != null)
            {
                var streamData = await file.OpenReadAsync();
                var bytes = new byte[streamData.Size];
                using (var dataReader = new DataReader(streamData))
                {
                    await dataReader.LoadAsync((uint)streamData.Size);
                    dataReader.ReadBytes(bytes);
                }
                var streamContent = new ByteArrayContent(bytes);
                content.Add(streamContent, "file");
            }
            //client.DefaultRequestHeaders.Add("Access-Token", AccessToken);
            var response = await client.PostAsync(new Uri(upload_url, UriKind.Absolute), content);
            if (response.IsSuccessStatusCode)
                return true;
        }
        catch { return false; }
        return false;
    }
