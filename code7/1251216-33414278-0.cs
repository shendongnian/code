        public ContentResult Save(FormCollection form)
		{
			try
			{
				var name = form["txtDialogName"];
				var filename = name + ".xml";
				byte[] bytes = null;
				foreach (string s in Request.Files)
				{
					var file = Request.Files[s];
					using (Stream inputStream = file.InputStream)
					{
						MemoryStream memoryStream = inputStream as MemoryStream;
						if (memoryStream == null)
						{
							memoryStream = new MemoryStream();
							inputStream.CopyTo(memoryStream);
						}
						bytes = memoryStream.ToArray();
					}
					break;
				}
				if (bytes == null)
				{
					var contentResult = new ContentResult
					{
						ContentType = "application/json",
						Content = null
					};
					return contentResult;
				}
				var basePath = ConfigurationManager.AppSettings["WatsonPath"];
				var username = ConfigurationManager.AppSettings["WatsonUsername"];
				var password = ConfigurationManager.AppSettings["WatsonPassword"];
				string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password)));
				var values = new[]
							 { new KeyValuePair<string, string>("name", filename) };
				using (var client = new HttpClient())
				using (var formData = new MultipartFormDataContent())
				{
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
					foreach (var keyValuePair in values)
					{
						formData.Add(new StringContent(keyValuePair.Value), string.Format("\"{0}\"", keyValuePair.Key));
					}
					formData.Add(new ByteArrayContent(bytes),
								   '"' + "file" + '"',
								   '"' + filename + '"');
					var response = client.PostAsync(basePath + "/v1/dialogs", formData).Result;
					var result = response.Content.ReadAsStringAsync().Result;
					if (!response.IsSuccessStatusCode)
					{
						var contentResult = new ContentResult
						{
							ContentType = "application/json",
							Content = response.ReasonPhrase
						};
						return contentResult;
					}
					var successResult = new ContentResult
					{
						ContentType = "application/json",
						Content = result
					};
					return successResult;
				}
			}
			catch (Exception ex)
			{
				HandleError(ex);
				var contentResult = new ContentResult
				{
					ContentType = "application/json",
					Content = "false"
				};
				return contentResult;
			}
		}
