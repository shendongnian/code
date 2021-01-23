    var Client = new HttpClient();
    string request;
    try
    {
	    using (Client)
	    {
		    request = await Client.GetStringAsync(new Uri(url));
	    }
    }
    catch (Exception)
    {
	    request = null;
    }
    return request;
