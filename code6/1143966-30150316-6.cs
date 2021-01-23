	wc.Headers.Add(HttpRequestHeader.Cookie, cookie);
	wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
	wc.Headers.Add(HttpRequestHeader.Accept, "application/json, text/javascript, */*; q=0.01");
	wc.Headers.Add("X-CSRF-Token", csrfToken);
	wc.Headers.Add("X-Requested-With", "XMLHttpRequest");
	
	string dataString = @"{""name"":""Meg"",""regi_number"":38}";
	byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
	byte[] responseBytes = wc.UploadData(new Uri("https://damp-sands-2243.herokuapp.com/students/"), "POST", dataBytes);
	string responseString = Encoding.UTF8.GetString(responseBytes);
	Console.WriteLine(responseString);
