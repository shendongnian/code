        void ProcessAuthentication (bool success) 
        	{
        		if (true == success) 
        		{
        			Debug.Log ("AUTHENTICATED!");
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
                     //EDIT: you need to load the achievements to use them
                     Social.LoadAchievements (ProcessLoadedAchievements);
                    Social.LoadScores(leaderboardID, CALLBACK) // Callback has to be a Action<IScore[]> callback
			    }
                 test.SetActive (false);
        		}
        		else
        		{
        			Debug.Log("Failed to authenticate");
                    signIn.SetActive (true);
        		}
        	}
 
    void ProcessLoadedAchievements (IAchievement[] achievements) {
    		if (achievements.Length == 0)
    		{
    			Debug.Log ("Error: no achievements found");
    		}
    		else
    		{
    			Debug.Log ("Got " + achievements.Length + " achievements");
    		}
    	}
