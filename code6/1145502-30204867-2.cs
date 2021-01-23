     public static WebResponse world(string symbol) {
	        // Create a new 'Uri' object with the specified string.
			Uri myUri =new Uri("http://yahoo.com");
			// Create a new request to the above mentioned URL.	
			WebRequest request= CreateWebRequest(myUri);
			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse response = request.GetResponse ();
          
          }
    
    private static HttpWebRequest CreateWebRequest(Uri uri)
    {
     var type = Type.GetType("System.Net.HttpRequestCreator, System, Version=4.0.0.0,Culture=neutral, PublicKeyToken=b77a5c561934e089");
        var creator = Activator.CreateInstance(type,nonPublic:true) as IWebRequestCreate;
        return creator.Create(uri) as HttpWebRequest;
    }
