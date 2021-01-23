    public async void getData(Action<IRestResponse> onDone)
    {           
        RestRequest request = new RestRequest("getData", Method.GET);
        //Execute ASYNC the rest request
        m_Client.ExecuteAsync (request, response =>
        {
            //Do my stuff with headers.
            string lCookie = response.Headers.ToList().Find(x => x.Name == "Cookie").Value.ToString();
            // Execute the onDone action with the received response
            onDone(response);
        });
    }
