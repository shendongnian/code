	private async Task<T> DecompressAsync<T>(HttpResponseMessage response)
	{
		if (!response.Content.Headers.ContentEncoding.Contains("gzip"))
			return await response.Content.ReadAsAsync<T>();
			
		using (GZipStream gzipStream = new GZipStream(
									   new MemoryStream(
											await response.Content.ReadAsByteArrayAsync()), 
									   		CompressionMode.Decompress))
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				await gzipStream.CopyToAsync(memoryStream);
				return JsonConvert.DeserializeObject<T>(
							Encoding.UTF8.GetString(memoryStream.ToArray()));
			}
		}
	}
