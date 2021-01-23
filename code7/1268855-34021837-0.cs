    	public void GetDataFromRestService()
		{
			var request = HttpWebRequest.Create("https://example.com/service/SomeMethod");
			SetBasicAuthHeader(request, "user", "password");
			request.ContentType = "application/json";
			request.Method = "GET";
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			{
				if (response.StatusCode != HttpStatusCode.OK)
				{
					Console.Out.WriteLine("ERROR: Server status code: {0}", response.StatusCode);
				}
				using (StreamReader reader = new StreamReader(response.GetResponseStream()))
				{
					var content = reader.ReadToEnd();
					if (string.IsNullOrWhiteSpace(content))
					{
						Console.Out.WriteLine("ERROR: Empty response.");
					}
					else
					{
						Console.Out.WriteLine("Response: {0}", content);
					}
				}
			}
		}
		public void SetBasicAuthHeader(WebRequest request, String userName, String userPassword)
		{
			string authInfo = userName + ":" + userPassword;
			authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
			request.Headers["Authorization"] = "Basic " + authInfo;
		}
