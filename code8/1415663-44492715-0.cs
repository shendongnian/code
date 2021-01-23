    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    statusCode = (int)response.StatusCode;
    ActivateCallback(responseCallback, response, url, string.Empty);
    
    var fieldStatusCode = response.GetType().GetField("m_StatusCode", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    {
    	var statusCodeNew = (HttpStatusCode)403;
    	fieldStatusCode.SetValue(response, statusCodeNew);
    }
    
    
    string responceBody = "{\"error\":{\"code\":\"AF429\",\"message\":\"Too many requests. Method=GetContents, PublisherId=00000000-0000-0000-0000-000000000000\"}}";
    
    var propStream = response.GetType().GetField("m_ConnectStream", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
    	System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(responceBody));
    	//response.ResponseStream = ms;//((System.Net.ConnectStream)(response.ResponseStream))
    	propStream.SetValue(response, ms);
    	ms.Position = 0;
    
    
    WebException ex1 = new WebException();
    var fieldResponce = ex1.GetType().GetField("m_Response", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    {
    	fieldResponce.SetValue(ex1, response);
    }
    e = null;
    throw ex1;
