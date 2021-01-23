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
        PlayGamesPlatform.Activate();
		Advertisement.Initialize ("NUMBER", true);
		test.SetActive (false);
         
        //EDIT:
        SignIn ();
		if (PlayerPrefs.HasKey("record"))
		{
			record.text = "Record actual: " + PlayerPrefs.GetInt("record");
			Analytics.CustomEvent ("Start Play", new Dictionary<string, object>{ { "Record", PlayerPrefs.GetInt("record")} });
		} else {
				record.text = "Consigue un record!!";
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
		if (Social.Active.localUser.authenticated) {
			Social.Active.ShowAchievementsUI ();
		} else {
			Social.Active.localUser.Authenticate ((bool success) => {
				if (success) {
					Social.Active.ShowAchievementsUI ();			
				}
			});
		}
	}
	public void OnMatching()
	{
		if (Social.Active.localUser.authenticated) {
			Social.Active.ShowLeaderboardUI ();
		} else {
			Social.Active.localUser.Authenticate ((bool success) => {
				if (success) {
					Social.Active.ShowLeaderboardUI ();		
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
		Social.Active.localUser.Authenticate (ProcessAuthentication);
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
    //EDIT:
	void ProcessAuthentication (bool success) 
	{
		if (true == success) 
		{
			Debug.Log ("AUTHENTICATED!");
			if (Social.Active.localUser.authenticated) 
			{
				Social.Active.LoadAchievements (ProcessLoadedAchievements);
				Social.Active.LoadScores (Fireball.GPGSIds.leaderboard_ranking, ProcessLoadedScores );
				if (PlayerPrefs.HasKey ("record"))
				{
					Social.Active.ReportScore (PlayerPrefs.GetInt ("record"),Fireball.GPGSIds.leaderboard_ranking, (bool report) => { });
				}
				signIn.SetActive (false);
				test.SetActive (true);
			}
		} else {
			Debug.Log("Failed to authenticate");
			signIn.SetActive (true);
		}
	 }
       
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
