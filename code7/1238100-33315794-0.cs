	public HttpResponseMessage Post()
		{
			var ch = new ClientHandler();
			using (MemoryStream rms = new MemoryStream(Request.Content.ReadAsByteArrayAsync().Result))
			{
				using (GZipStream unzip = new GZipStream(rms, CompressionMode.Decompress))
				{
					ch.Requests = XElement.Load(unzip);
				}
			}
			MemoryStream outstream = new MemoryStream();
			try
			{
				ch.Start();
				using (GZipStream zip = new GZipStream(outstream, CompressionMode.Compress, true))
				{
					ch.Responses.Save(zip);
				}
			}
			catch (Exception ex)
			{
				XElement responses = new XElement("Responses");
				responses.Add(new XElement("Error", ex.Message));
				using (GZipStream zip = new GZipStream(outstream, CompressionMode.Compress, true))
				{
					responses.Save(zip);
				}
			}
			finally
			{
				ch.Dispose();
			}
			outstream.Position = 0;
			HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
			result.Content = new StreamContent(outstream);
			result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
			return result;
		}
