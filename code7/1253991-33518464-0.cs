    public IObservable<List<Stuff>> GetGoodStuff()
    {
    	var invalidate = Observable.FromAsync(InvalidateAccessTokenAsync)
                    .Select(x => string.Empty)
    				.Select(x => Observable.Throw<Exception>(new Exception()))
    				.Switch()
    				.Replay()
    				.RefCount();
    
    	return Observable.FromAsync(GetAccessTokenAsync)
    		.SelectMany(accessToken =>
    		{
    			return httpClient.SendAsync(request);
    		})
    		.SelectMany(response => 
    		{ 
    			if (response.StatusCode == HttpStatusCode.Unauthorized)
    			{
    				return invalidate;
    			}
    		
    			response.EnsureSuccessStatusCode(); 
    			return response.Content.ReadAsStringAsync().ToObservable(); 
    		})
    		.Select(json => 
    		{
    			return JsonConvert.DeserializeObject<List<Stuff>>(json);
    		})
    		.Retry(1);
    }
