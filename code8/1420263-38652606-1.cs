    private const string GoogleApiTokenInfoUrl = "https://www.googleapis.com/oauth2/v3/tokeninfo?id_token={0}";
    public ProviderUserDetails GetUserDetails(string providerToken)
    {
    	var httpClient = new MonitoredHttpClient();
    	var requestUri = new Uri(string.Format(GoogleApiTokenInfoUrl, providerToken));
    
    	HttpResponseMessage httpResponseMessage;
    	try
    	{
    		httpResponseMessage = httpClient.GetAsync(requestUri).Result;
    	}
    	catch (Exception ex)
    	{
    		return null;
    	}
    	
    	if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
    	{
    		return null;
    	}
    
    	var response = httpResponseMessage.Content.ReadAsStringAsync().Result;
    	var googleApiTokenInfo = JsonConvert.DeserializeObject<GoogleApiTokenInfo>(response);
    
    	if (!SupportedClientsIds.Contains(googleApiTokenInfo.aud))
    	{
    		Log.WarnFormat("Google API Token Info aud field ({0}) not containing the required client id", googleApiTokenInfo.aud);
    		return null;
    	}
    
    	return new ProviderUserDetails
    	{
    		Email = googleApiTokenInfo.email,
    		FirstName = googleApiTokenInfo.given_name,
    		LastName = googleApiTokenInfo.family_name,
    		Locale = googleApiTokenInfo.locale,
    		Name = googleApiTokenInfo.name,
    		ProviderUserId = googleApiTokenInfo.sub
    	};
    }
