    public async Task PostSampleAsync()
    {
        var request = new MvxJsonRestRequest<UserRequest>
            ("http://jsonplaceholder.typicode.com/posts")
        {
            Body = new UserRequest
            {
                Title = "foo",
                Body = "bar",
                UserId = 1
            }
        };
    
        var client = Mvx.Resolve<IMvxJsonRestClient>();
        var response = await client.MakeRequestForAsync<UserResponse>(request);
    
        // Check response.StatusCode if matches your expected status code
        if (response.StatusCode == System.Net.HttpStatusCode.Created)
        {
            // interrogate the response object
            UserResponse user = response.Result;
        }
        else
        {
            // do something in the case of error/time-out/unexpected response code
        }
    }
