    	void AuthCallback (ILoginResult loginResult)
	{
		if (loginResult.Error != null) {
			Util.LogError ("FREAK OUT WHILE LOGIN\n" + loginResult.Error); 
		} else if (!FB.IsLoggedIn) {
			Debug.LogWarning ("Canceled by the user");
		} else {
			Debug.Log ("Login was succesfull");
			Debug.Log ("Players User id is: " + AccessToken.CurrentAccessToken.UserId);
			FB.API ("me?fields=id,name,email,friends.fields(first_name),first_name", HttpMethod.GET, GetFriendIDs);
		}
	}
	void GetFriendIDs (IGraphResult result)
	{
		if (result.Error != null) {
			Util.LogError ("\n\nFREAK OUT FROM JSON\n\n" + result.Error + "\n\n");
			FB.API ("me?fields=id,name,email,friends.fields(first_name),first_name", HttpMethod.GET, GetFriendIDs);
		} else if (result.RawResult != string.Empty) {
			List<object> rawJSON = Util.DeserializeJSONFriends (result.RawResult);
			foreach (object item in rawJSON) {		
				friends = (Dictionary<string, object>)item;	
				Debug.Log (friends ["id"]);
			}			
			Debug.Log ("RawResult" + result.RawResult);
		}				
		Application.LoadLevel ("Main");
	}
