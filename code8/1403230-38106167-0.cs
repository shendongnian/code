    [HttpGet]
    [ActionName("Index")]
    public HttpResponseMessage Index()
    {
    	var path = "your path to index.html";
        var response = new HttpResponseMessage();
    	response.Content = File.ReadAllText(path);
    	response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
    	return response;
    }
