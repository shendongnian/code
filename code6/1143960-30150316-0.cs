    	WebClient wc = new WebClient();
		wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
		string dataString = @"{""name"":""Meg"",""regi_number"":38}";
		byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
		byte[] responseBytes = wc.UploadData(new Uri("https://damp-sands-2243.herokuapp.com/students/"), "POST", dataBytes);
		string responseString = Encoding.UTF8.GetString(responseBytes);
		Console.WriteLine(responseString);
