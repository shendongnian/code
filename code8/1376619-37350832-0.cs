    private static async Task<string>getWebTitle(string webUrl) 
    { 
	//Creating Password 
	const string PWD = "softjam.1"; 
	const string USER = "bubu@zsis376.onmicrosoft.com"; 
	const string RESTURL = "{0}/_api/web?$select=Title"; 
	//Creating Credentials 
	var passWord = new SecureString(); 
	foreach (var c in PWD) passWord.AppendChar(c); 
	var credential = new SharePointOnlineCredentials(USER, passWord); 
	//Creating Handler to allows the client to use credentials and cookie 
	using (var handler = new HttpClientHandler() { Credentials = credential }) 
	{ 
		//Getting authentication cookies 
		Uri uri = new Uri(webUrl); 
		handler.CookieContainer.SetCookies(uri, credential.GetAuthenticationCookie(uri)); 
		//Invoking REST API 
		using (var client = new HttpClient(handler)) 
		{ 
			client.DefaultRequestHeaders.Accept.Clear(); 
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
			HttpResponseMessage response = await client.GetAsync(string.Format(RESTURL, webUrl)).ConfigureAwait(false); 
			response.EnsureSuccessStatusCode(); 
			string jsonData = await response.Content.ReadAsStringAsync(); 
			return jsonData; 
		} 
	} 
}
