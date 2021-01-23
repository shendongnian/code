	private string SendHttpRequest(string url, out int statusCode, string method = "GET", object postData = null, string contentType = "application/json")
	{
		bool isPost = method.Equals("POST", StringComparison.CurrentCultureIgnoreCase);
		byte[] content = new ASCIIEncoding().GetBytes(isPost ? JsonConvert.SerializeObject(postData) : "");
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.AllowAutoRedirect = true;
		request.Method = method;
		request.ContentType = contentType;
		request.ContentLength = postData == null ? 0 : content.Length;
		if (isPost && postData != null)
		{
			Stream reqStream = request.GetRequestStream();
			reqStream.Write(content, 0, content.Length);
		}
		HttpWebResponse response = null;
        
        //Get the response via request.GetResponse, but if that fails,
        //retrieve the response from the exception
		try
		{
			response = (HttpWebResponse)request.GetResponse();
		}
		catch (WebException ex)
		{
			response = (HttpWebResponse)ex.Response;
		}
		string result;
		using (StreamReader sr = new StreamReader(response.GetResponseStream()))
		{
			result = sr.ReadToEnd();
		}
		statusCode = (int)response.StatusCode;
		response.Close();
		return result;
	}
