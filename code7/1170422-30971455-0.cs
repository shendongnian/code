    Public static void Main (string[] args)
    {
    	using (var client = new WebClient())
    	{
    			var Parameters = new NameValueCollection {
    	        {action = "login"},
    	        {login = "demouser"},
    	        {password = "xxxx"},
    	        {checksum = "xxxx"}
    		
     	        httpResponse = client.UploadValues( "https://devcloud.fulgentcorp.com/bifrost/ws.php", Parameters);
                Console.WriteLine (httpResponse);
        }
    
    }
