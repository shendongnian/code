    public static class HttpExtensions
    {
    	public static Task<HttpResponseMessage> PostAsXmlWithSerializerAsync<T>(this HttpClient client, Uri requestUri, T value, CancellationToken cancellationToken)
    	{
    		return client.PostAsync(requestUri, value,
                          new XmlMediaTypeFormatter { UseXmlSerializer = true },
                          cancellationToken);
    	}
    }
