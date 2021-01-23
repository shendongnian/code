    public void LogIn(string username, string password)
    {
    	var request = (HttpWebRequest)WebRequest.Create("http://carkit.kg/api/v1/auth/login/");
    
    	var postData = "username=" + username;
    	    postData += "&password=" + password;
    	var data = Encoding.UTF8.GetBytes(postData);
    
    	request.Method = "POST";
    	request.ContentType = "application/x-www-form-urlencoded";
    	request.ContentLength = data.Length;
    
    	using (var stream = request.GetRequestStream())
    	{
    	    stream.Write(data, 0, data.Length);
    	}
    	try {
    		var response = (HttpWebResponse)request.GetResponse();
    		if (response.StatusCode == HttpStatusCode.OK) {
                // Successful login
    		} 
    		else {
    			serverMessenger.SendErrorMessage(0);
    			Debug.LogError("Cannot Find User. TryToLogin finished");
    		}
    	} catch (WebException e) {
    		serverMessenger.SendErrorMessage(0);
    		Debug.LogError("Cannot Find User. TryToLogin finished");
    	}
    }
