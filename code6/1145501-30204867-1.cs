       public static WebResponse world(string symbol) {
	        // Create a new 'Uri' object with the specified string.
			Uri myUri =new Uri("http://yahoo.com");
			// Create a new request to the above mentioned URL.	
			WebRequest request= WebRequest.Create(myUri);
			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse response = request.GetResponse ();
          
          }
