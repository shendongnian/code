    public string PostFileUsingApi()
	{
		string result = "";
		string param1 = "value1";
		using (var handler = new HttpClientHandler()) {
			using (var client = new HttpClient(handler) { BaseAddress = new Uri("http://localhost:8008") }) {
				client.Timeout = new TimeSpan(0, 20, 0);
                StorageFile storageFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
                Stream stream = await storageFile.OpenStreamForReadAsync();
				var requestContent = new MultipartFormDataContent();
                StreamContent fileContent = new StreamContent(stream);
				fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") {
					Name = "imagekey", //content key goes here
					FileName = "myimage"
				};
				fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/bmp");
				requestContent.Add(fileContent);
				client.DefaultRequestHeaders.Add("ClientSecretKey", "ClientSecretValue");
				HttpResponseMessage response = client.PostAsync("api/controller/UploadData?param1=" + HttpUtility.UrlEncode(param1), requestContent).Result;
				if (response.StatusCode == System.Net.HttpStatusCode.OK) {
					result = response.Content.ReadAsStringAsync().Result
				} else {
                    result = "";
				}
			}
		}
		return result;
	}
