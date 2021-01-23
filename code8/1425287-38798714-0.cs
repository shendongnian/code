    public void PostSample()
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
        client.MakeRequestFor(request,
            (MvxDecodedRestResponse<UserResponse> response) =>
            {
                // do something with the response.StatusCode and response.Result
            },
            error =>
            {
                // do something with the error
            });
    }
