    const string ContentTypePrefix = "Content-Type: ";
    
    AlternateView htmlView = null;
    var linkedResources = new List<LinkedResource>();
    
    var content = File.ReadAllText("report.mhtml");
    var startIndex = content.IndexOf(ContentTypePrefix, StringComparison.OrdinalIgnoreCase) + ContentTypePrefix.Length;
    var endIndex = content.IndexOf("\"", startIndex, StringComparison.Ordinal) + 1;
    var contentType = content.Substring(startIndex, endIndex);
    using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
    {
    	using (var stream = new StreamContent(memoryStream))
    	{
    		stream.Headers.ContentType = MediaTypeHeaderValue.Parse(contentType);
    		if (!stream.IsMimeMultipartContent())
    		{
    			throw new Exception("Not correct format.");
    		}
    		var parts = stream.ReadAsMultipartAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    		foreach (var part in parts.Contents)
    		{
    			part.Headers.ContentType.CharSet = part.Headers.ContentType.CharSet?.Replace("\"", string.Empty); // Needed since the SSRS report defaults the charset to \"utf-8\", instead of utf-8 and the code fails to find the correct encoder
    			var compressedContent = part.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
    			if (!part.Headers.ContentType.MediaType.Contains("image"))
    			{
    				var encoding = Encoding.GetEncoding(part.Headers.ContentType.CharSet);
    				var partContent = encoding.GetString(Convert.FromBase64String(compressedContent));
    				htmlView = AlternateView.CreateAlternateViewFromString(partContent, encoding, part.Headers.ContentType.MediaType);
    			}
    			else
    			{
    				linkedResources.Add(new LinkedResource(new MemoryStream(Convert.FromBase64String(compressedContent)), part.Headers.ContentType.MediaType)
    				{
    					ContentId = part.Headers.ContentDisposition.FileName.Replace("\"", string.Empty)
    				});
    			}
    		}
    	}
    }
    foreach (var linkedResource in linkedResources)
    {
    	htmlView?.LinkedResources.Add(linkedResource);
    }
    
    using (var message = new MailMessage("from@mail.com", "to@mail.com", "Subject", string.Empty))
    {
    	message.BodyEncoding = Encoding.UTF8;
    	message.AlternateViews.Add(htmlView);
    	using (var client = new SmtpClient("smtpserver.com", 25))
    	{
    		client.Send(message);
    	}
    }
