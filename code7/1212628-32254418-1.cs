	private string RestRequest(string URL, RestSharp.Method Method)
	{
		var Client = new RestClient();
		string requestUrl;
		bool hasBackslashArgument = ParseEncodedBackSlash(URL, out requestUrl);
        RestRequest request;
		if (hasBackslashArgument)
		{
            request = new RestRequest(requestUrl, Method);
			request.AddUrlSegment("segment", "%2F");
		}
        else
        {
            request = new RestRequest(URL, Method);
        }
		IRestResponse response = Client.Execute(request);
		return response.Content;
	}
	private bool ParseEncodedBackSlash(string url, out string preformattedString)
	{
		preformattedString = null;
		var urlSegments = url.Split(new string[] { "%2F" }, StringSplitOptions.None);
		if (urlSegments.Length == 0) return false;
		preformattedString = string.Join("{segment}", urlSegments);
		return true;
	}
