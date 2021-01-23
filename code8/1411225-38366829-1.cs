    client.ExecuteAsync(request, response => 
    {
        int sc = (int)response.StatusCode;
        if (response.StatusCode != HttpStatusCode.OK)
        {
            // display the status code to the user
        }
    });
