		private const string UploadMediaURL = "https://upload.twitter.com/1.1/media/upload.json";
       private const string PostTweetURL = "https://api.twitter.com/1.1/statuses/update.json";
		public static IEnumerator PostTweet(string text, string consumerKey, string consumerSecret, AccessTokenResponse response, PostTweetCallback callback)
		{
			Dictionary<string, string> mediaParameters = new Dictionary<string, string>();
            var imageData = File.ReadAllBytes(Application.persistentDataPath +"/Image.png");
            string encoded64ImageData = Convert.ToBase64String(imageData);
            mediaParameters.Add("media_data", encoded64ImageData );
        // Add data to the form to post.
            WWWForm mediaForm = new WWWForm();
            mediaForm.AddField( "media_data", encoded64ImageData );
        // HTTP header
            Dictionary<string, string> mediaHeaders = new Dictionary<string, string>();
            string auth = GetHeaderWithAccessToken("POST", UploadMediaURL, consumerKey, consumerSecret, response, mediaParameters);
            mediaHeaders.Add( "Authorization", auth );
            mediaHeaders.Add( "Content-Transfer-Encoding", "base64" );
            WWW mw = new WWW(UploadMediaURL, mediaForm.data, mediaHeaders);
            yield return mw;
			string mID = Regex.Match(mw.text, @"(\Dmedia_id\D\W)(\d*)").Groups[2].Value;
			Debug.Log ("response from media request : " + mw.text);
			Debug.Log ("mID = " + mID);
			if (!string.IsNullOrEmpty (mw.error)) {
				Debug.Log (string.Format ("PostTweet - failed. {0}\n{1}", mw.error, mw.text));
				callback (false);
			} else {
				string error = Regex.Match (mw.text, @"<error>([^&]+)</error>").Groups [1].Value;
				if (!string.IsNullOrEmpty (error)) {
					Debug.Log (string.Format ("PostTweet - failed. {0}", error));
					callback (false);
				} else {
					callback (true);
				}
			}
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("status", text);
			parameters.Add ("media_ids", mID);
			// Add data to the form to post.
			WWWForm form = new WWWForm();
			form.AddField("status", text);
			form.AddField ("media_ids", mID);
			// HTTP header
			var headers = new Dictionary<string, string>();
			headers["Authorization"] = GetHeaderWithAccessToken("POST", PostTweetURL, consumerKey, consumerSecret, response, parameters);
			WWW web = new WWW(PostTweetURL, form.data, headers);
			yield return web;
			if (!string.IsNullOrEmpty(web.error))
			{
				Debug.Log(string.Format("PostTweet - failed. {0}\n{1}", web.error, web.text));
				callback(false);
			}
			else
			{
				string error = Regex.Match(web.text, @"<error>([^&]+)</error>").Groups[1].Value;
				if (!string.IsNullOrEmpty(error))
				{
					Debug.Log(string.Format("PostTweet - failed. {0}", error));
					callback(false);
				}
				else
				{
					callback(true);
				}
			}
		}
