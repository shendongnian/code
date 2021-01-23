    using (var client = new HttpClient())
    {
    	using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
    	{
    		using (var stream = GenerateStreamFromString(SerializeToXml(p)))
    		{
    			StreamContent streamContent = new StreamContent(stream);
    			streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    
    			content.Add(streamContent, "file", "post.xml");
    
    			using (var message = client.PostAsync("http://example.com/upload.php", content).Result)
    			{
    				string response = message.Content.ReadAsStringAsync().Result;
    			}
    		}
    	}
    }
