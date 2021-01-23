	// Query string parameters
    NameValueCollection queryStringParameters = new NameValueCollection();
    queryStringParameters.Add("someOtherParam", "foo");
	client.QueryString = queryStringParameters;
	
	// Request body parameters
	NameValueCollection requestParameters = new NameValueCollection();
	requestParameters.Add("param", param);
    client.UploadValues(uri, method, requestParameters);
