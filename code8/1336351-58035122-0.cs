    private void InitializeClient()
    {
         _client = new RestClient(BASE_URL);           
         _client.DefaultParameters.Add(new Parameter("Authorization",
                    string.Format("Bearer " + TOKEN), 
                    ParameterType.HttpHeader));
    }
