    buttonListaIntereses.Click += async delegate {
        var response = await ApiInterface.Instance.getData();
        LaunchResponseActivity(response);
    };
    
    public void LaunchResponseActivity(IRestResponse response)
    {
        Intent displayMessage = new Intent(this, typeof(DisplayMessage));
        //Put info in Extra for the new screen.
        displayMessage.PutExtra("content", response.Content);
        StartActivity(displayMessage);
    }
    
    public async Task<IRestResponse> getData()
    {           
        RestRequest request = new RestRequest("getData", Method.GET);
        
        var cancellationTokenSource = new CancellationTokenSource();
    
        var restResponse = await client.ExecuteTaskAsync(request, cancellationTokenSource.Token);
        
        //Do my stuff with headers.
        string lCookie = restResponse.Headers.ToList().Find(x => x.Name == "Cookie").Value.ToString();
        
        return restResponse;
    }
