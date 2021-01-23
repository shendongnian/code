    public async static Task DownloadByteArray(string url)
    {
        using (var client = new HttpClient(new NativeMessageHandler())) 
        {
            try
            {
                using (var response = await client.GetAsync(new Uri (url))) 
                {
                    using (var responseContent = response.Content) 
				    {
						var byteArray = await responseContent.ReadAsByteArrayAsync();
                        var folderPath = System.IO.Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments), "Downloads");
			            System.IO.Directory.CreateDirectory (folderPath);
			            var extension = url.Split ('.').Last ();
			            string filename = System.IO.Path.Combine (folderPath, DateTime.Now.ToString("yyyyMMddhhmmss")+"."+ extension);
                        File.WriteAllBytes (filename,byteArray);
					}
				}
			}
			catch (Exception ex)
			{
					
			}
		}
	}
