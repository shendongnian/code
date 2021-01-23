            Uri url = new Uri(val);
			bool result = true;
            // keep all our cookies for the duration of our calls
			var cookies = new CookieContainer();
			System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            // assign our CookieContainer to the new request
			req.CookieContainer = cookies;
			string source = String.Empty;
			Uri responseURI;
			try
			{
