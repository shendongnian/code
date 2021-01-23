	using (HttpClient client = new HttpClient())
	{
		Uri url = new Uri("http://radioa24.info/ramowka.php");
		HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
		Task<HttpResponseMessage> responseAsync = client.SendRequestAsync(httpRequest).AsTask();
		responseAsync.Wait();
		responseAsync.Result.EnsureSuccessStatusCode();
		Task<IBuffer> asyncBuffer = responseAsync.Result.Content.ReadAsBufferAsync().AsTask();
		asyncBuffer.Wait();
		byte[] resultByteArray = asyncBuffer.Result.ToArray();
		string responseString = Encoding.UTF8.GetString(resultByteArray, 0, resultByteArray.Length);
		responseAsync.Result.Dispose();
	}
