    public HttpResponseMessage GetCsv()
    {
    	var csv = "whatever goes here";
    	var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));
    	var message = new HttpResponseMessage()
    	{
    		Content = new StreamContent(stream)
    	};
    	message.Headers.Add("Content-type", "text/csv");
    	return message;
    }
