	private async Task<T> DecompressAsync<T>(HttpResponseMessage response)
	{
		if (!response.Content.Headers.ContentEncoding.Contains("gzip"))
			return await response.Content.ReadAsAsync<T>();
			
		using (GZipStream gzipStream = new GZipStream(
									   new MemoryStream(
											await response.Content.ReadAsByteArrayAsync()), 
									   		CompressionMode.Decompress))
		{
			byte[] buffer = new byte[8192];
			using (MemoryStream memoryStream = new MemoryStream())
			{
				int count;
				do
				{
					count = await gzipStream.ReadAsync(buffer, 0, 8192);
					if (count > 0)
						await memoryStream.WriteAsync(buffer, 0, count);
				}
				while (count > 0);
				return JsonConvert.DeserializeObject<T>(
							Encoding.UTF8.GetString(memoryStream.ToArray()));
			}
		}
	}
	
