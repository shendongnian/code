    void  LoginToTwitter ()
		{
			var auth = new OAuth1Authenticator(
				"some_key",
				"some_key",
				new Uri("https://api.twitter.com/oauth/request_token"),
				new Uri("https://api.twitter.com/oauth/authorize"),
				new Uri("https://api.twitter.com/oauth/access_token"),
				new Uri("https://mobile.twitter.com/"));
			//save the account data in the authorization completed even handler
			auth.Completed += GetTwitterData;
			var ui = auth.GetUI(Activity);
			StartActivity(ui);
		}
		public async void GetTwitterData( object sender, AuthenticatorCompletedEventArgs e )
		{
			//use the account object and make the desired API call
			if (e.IsAuthenticated)
				Console.WriteLine("Logged in");
			
			var request = new OAuth1Request(
				"GET",
				new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
				null,
				e.Account, true);
			await request.GetResponseAsync().ContinueWith(t =>
				{
					if (!t.IsFaulted && !t.IsCanceled){
					var res = t.Result;
					var resString = res.GetResponseText();
					//Console.WriteLine("Result Text: " + resString);
					var jo = Newtonsoft.Json.Linq.JObject.Parse(resString);
					imageUrl = new Java.Net.URL((string)jo["profile_image_url"]);
					var twitterId = jo["id"];
					
					}
				}, UIScheduler);
			var userID = e.Account.Properties["user_id"];
			var name = e.Account.Properties["screen_name"];
			var oauth_consumer_key = e.Account.Properties["oauth_consumer_key"];
			var oauth_consumer_secret = e.Account.Properties["oauth_consumer_secret"];
			var oauth_token = e.Account.Properties["oauth_token"];
			var oauth_token_secret = e.Account.Properties["oauth_token_secret"];
			var authData = new Dictionary<string,string>();
			authData.Add("user_id",userID.ToString());
			authData.Add("screen_name",name.ToString());
			authData.Add("oauth_consumer_key",oauth_consumer_key.ToString());
			authData.Add("oauth_consumer_secret",oauth_consumer_secret.ToString());
			authData.Add("oauth_token",oauth_token.ToString());
			authData.Add("oauth_token_secret",oauth_token_secret.ToString());
			await ParseLoginOrCreate(authData);
		}
		public async Task<ParseUser> ParseLoginOrCreate(Dictionary<string,string> authInfo) 
		{
			var rest = new RestSharp.RestClient ("https://api.parse.com");
			var req = new RestSharp.RestRequest ("1/users/", RestSharp.Method.POST);
			req.AddHeader ("X-Parse-Application-Id", "some_key");
			req.AddHeader ("X-Parse-REST-API-Key", "some_key");
			req.AddHeader ("Content-Type", "application/json");
			var payload = "{ \"authData\": { \"twitter\": { ";
			payload += "\"id\": \"" + authInfo["user_id"] + "\", ";
			payload += "\"screen_name\": \"" + authInfo["screen_name"] + "\", ";
			payload += "\"consumer_key\": \"" + authInfo["oauth_consumer_key"] + "\", ";
			payload += "\"consumer_secret\": \"" + authInfo["oauth_consumer_secret"] + "\", ";
			payload += "\"auth_token\": \"" + authInfo["oauth_token"] + "\", ";
			payload += "\"auth_token_secret\": \"" + authInfo["oauth_token_secret"] + "\" ";
			payload += "} } }";
			req.AddParameter("application/json", payload, RestSharp.ParameterType.RequestBody);
			RestSharp.IRestResponse res = null;
			var result = await Task<JContainer>.Run(()=>{
				res = rest.Execute(req);
				var content = res.Content;
				return JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JContainer>(content);
			});
			var sessionToken = (String)result["sessionToken"];
			var objectId = (String)result["objectId"];
			if (res.StatusCode == System.Net.HttpStatusCode.Created)
			{
				req = new RestSharp.RestRequest ("1/users/" + objectId, RestSharp.Method.PUT);
				req.AddHeader ("X-Parse-Application-Id", "some_key");
				req.AddHeader ("X-Parse-REST-API-Key", "some_key");
				req.AddHeader ("X-Parse-Session-Token", sessionToken);
				req.AddHeader ("Content-Type", "application/json");
				req.AddParameter("application/json", "{ \"username\": \"" + authInfo["screen_name"] + "\" }", RestSharp.ParameterType.RequestBody);
				result = await Task<JContainer>.Run(() => {
					res= rest.Execute(req);
					var content = res.Content;
					return JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JContainer>(content);
				});
			}
			await ParseUser.BecomeAsync (sessionToken);
			return ParseUser.CurrentUser;
		}
