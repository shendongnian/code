    FirebaseMessaging.getInstance().subscribeToTopic("news");
    
    public String SendNotificationFromFirebaseCloud()
	{
		var result = "-1";
		var webAddr = "https://fcm.googleapis.com/fcm/send";
		var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
		httpWebRequest.ContentType = "application/json";
		httpWebRequest.Headers.Add("Authorization:key=" + YOUR_FIREBASE_SERVER_KEY);
		httpWebRequest.Method = "POST";
		using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
		{
			string json = "{\"to\": \"/topics/news\",\"data\": {\"message\": \"This is a Firebase Cloud Messaging Topic Message!\",}}";
			streamWriter.Write(json);
			streamWriter.Flush();
		}
		var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
		{
			result = streamReader.ReadToEnd();
		}
		return result;
	}
