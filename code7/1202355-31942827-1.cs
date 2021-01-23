    public async Task CreateBug(Bug bug)
    {
    	string token = Settings.Default.token;
    	string requestUrl = "https://xxx.visualstudio.com/defaultcollection/xxx/_apis/wit/workitems/$Bug?api-version=1.0";
    	HttpClientHandler httpClientHandler = new HttpClientHandler
    	{
    		Proxy = this.GetProxy(),
    		UseProxy = true,
    		UseDefaultCredentials = true
    	};
    	HttpClient httpClient = new HttpClient(httpClientHandler);
    	httpClient.DefaultRequestHeaders.Accept.Add(
    				new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    
    	httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
    		Convert.ToBase64String(
    			System.Text.ASCIIEncoding.ASCII.GetBytes(
    				string.Format("{0}:{1}", "me", token))));
    	var method = new HttpMethod("PATCH");
    	var request = new HttpRequestMessage(method, requestUrl)
    	{
    		Content = new StringContent(GetStrJsonData(), Encoding.UTF8,
    			"application/json-patch+json")
    	};
    	HttpResponseMessage hrm = await httpClient.SendAsync(request);
    	Response = hrm.Content;
    }
