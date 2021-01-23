    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;
    using UnityEngine.Advertisements;
    using System.Collections;
    using System.Collections.Generic;
    using GooglePlayGames;
    using UnityEngine.SocialPlatforms;
    using GooglePlayGames.BasicApi;
    using UnityEngine.Analytics;
    public class Menu : MonoBehaviour {
	public Text record;
	public GameObject test;
	/**
	 	Indicador del jugador de que no ha iniciado sesión, y no podrá acceder al  ranking ni a los logros.
	 */
	public GameObject signIn;
	void Start()
	{		
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.InitializeInstance(config);
		GooglePlayGames.PlayGamesPlatform.DebugLogEnabled = false;
		Advertisement.Initialize ("NUMBER", true);
		test.SetActive (false);
         
        //EDIT:
        SignIn ();
        if (Social.localUser.authenticated) 
		{
			signIn.SetActive (false);	
			Social.LoadAchievements (ProcessLoadedAchievements);
			Social.LoadScores (Fireball.GPGSIds.leaderboard_ranking, ProcessLoadedScores );
		}
		if (PlayerPrefs.HasKey("record"))
		{
			record.text = "Record actual: " + PlayerPrefs.GetInt("record");
			Analytics.CustomEvent ("Start Play", new Dictionary<string, object>{ { "Record", PlayerPrefs.GetInt("record")} });
            //I do here, because it must update every time I load the scene even if I'm sign in.
			if (Social.localUser.authenticated) 
			{
				Social.ReportScore (PlayerPrefs.GetInt ("record"), Fireball.GPGSIds.leaderboard_ranking, (bool success) => { });
			}
		} else {
				record.text = "Consigue un record!!";
		}
		if (Social.localUser.authenticated) 
		{
			signIn.SetActive (false);			
		}
	}
	public void OnPlay()
	{
		ShowAd ();
		SceneManager.LoadScene("Jugar");
		Time.timeScale = 0;
	}
	public void OnArchievements()
	{
		if (Social.localUser.authenticated) {
			Social.ShowAchievementsUI ();
		} else {
			Social.localUser.Authenticate ((bool success) => {
				if (success) {
					Social.ShowAchievementsUI ();			
				}
			});
		}
	}
	public void OnMatching()
	{
		if (Social.localUser.authenticated) {
			Social.ShowLeaderboardUI ();
		} else {
			Social.localUser.Authenticate ((bool success) => {
				if (success) {
					Social.ShowLeaderboardUI ();		
				}
			});
		}
	}
	public void OnExit()
	{
		Analytics.CustomEvent ("Stop Play", new Dictionary<string, object>{ { "Record", PlayerPrefs.GetInt("record")} });
		Application.Quit();
	}
	public void SignIn()
	{
		Social.localUser.Authenticate (ProcessAuthentication);
	}
	public void Later()
	{
		signIn.SetActive (false);
	}
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
	void ProcessAuthentication (bool success) 
	{
		if (true == success) 
		{
			Debug.Log ("AUTHENTICATED!");
			if (Social.localUser.authenticated) 
			{
				signIn.SetActive (false);
				test.SetActive (true);
			}
		} else {
			Debug.Log("Failed to authenticate");
			signIn.SetActive (true);
		}
	 }
       //EDIT:
      void ProcessLoadedAchievements (IAchievement[] achievements) 
	{
		if (achievements.Length == 0)
		{
			Debug.Log ("Error: no achievements found");
		}
		else
		{
			Debug.Log ("Got " + achievements.Length + " achievements");
		}
	}
	void ProcessLoadedScores (IScore[] scores) 
	{
		if (scores.Length == 0)
		{
			Debug.Log ("Error: no scores found");
		}
		else
		{
			Debug.Log ("Got " + scores.Length + " scores");
		}
	}
    }
