    void SaveData()
    {
        StartCoroutine(SubmitData());
    }
    IEnumerator SubmitData()
    {
      // create and instance of WWWForm
      WWWForm form = new WWWForm();
      // Add Some data
      form.AddField( "playerName", "Bob" );
      form.AddField( "playerScore", 100 );
      //Get reference to headers so we can modify them.
      Hashtable headers = form.headers;
      byte[] rawData = form.data;
      string url = "SERVER_IP/WEB_NAME";
      //Add the authorisation header with username/password to access the endpoint
      headers["Authorization"] = "Basic " + System.Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("username:password"));
      // Post the request
      WWW www = new WWW(url, rawData, headers);
      yield return www;
    }
