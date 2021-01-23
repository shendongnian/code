    public async static Task<string> UploadFiles(StorageFile[] files)
        {
            try
            {
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("ru"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "token=" + SessionToken);
                var content = new System.Net.Http.MultipartFormDataContent();
                foreach (var file in files)
                {
                    if (file != null)
                    {
                        var streamData = await file.OpenReadAsync();
                        var bytes = new byte[streamData.Size];
                        using (var dataReader = new DataReader(streamData))
                        {
                            await dataReader.LoadAsync((uint)streamData.Size);
                            dataReader.ReadBytes(bytes);
                        }
                        string fileToUpload = file.Path;
                        using (var fstream = await file.OpenReadAsync())
                        {
                            var streamContent = new System.Net.Http.ByteArrayContent(bytes);
                            streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                            {
                                Name = "files[]",
                                FileName = Path.GetFileName(fileToUpload),
                            };
                            content.Add(streamContent);
                        }
                    }
                }
                var response = await client.PostAsync(new Uri(UploadFilesURI, UriKind.Absolute), content);
                var contentResponce = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<API.ResponceUploadFiles.RootObject>(contentResponce);
                return result.cache;
            }
            catch { return ""; }
           
        }
