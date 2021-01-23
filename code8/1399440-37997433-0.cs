        void Start()
             {
        //added code
         PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
             PlayGamesPlatform.InitializeInstance(config);
             GooglePlayGames.PlayGamesPlatform.DebugLogEnabled = false;
             //GooglePlayGames.PlayGamesPlatform.Activate (); //this is wrong
    
          //WHAT YOU ARE MISSING
          PlayGamesPlatform.Activate();
          //END OF WHAT YOU ARE MISSING
        
                 Advertisement.Initialize ("CORRECT_NUMBER", true);
            
            
                 if (PlayerPrefs.HasKey("record"))
                 {
                     record.text = "Record actual: " + PlayerPrefs.GetInt("record");
                     Analytics.CustomEvent ("Start Play", new Dictionary<string, object>{ { "Record", PlayerPrefs.GetInt("record")} });
    
          //you should do this once the user is authenticated and logged in
                     if (Social.localUser.authenticated) 
                     {
                         Social.ReportScore (PlayerPrefs.GetInt ("record"), "CORRECT_CODE", (bool success) => { });
                     }
                 } else {
                         record.text = "Consigue un record!!";
                 }
            
                 if (Social.localUser.authenticated) 
                 {
                     signIn.SetActive (false);           
                 }
                 test.SetActive (false);
             }
