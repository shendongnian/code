    public class GameSetup : MonoBehaviour 
    {
        void Start()
    	{		
    		prevMousePosition = Input.mousePosition;
    	}
    
    	void Update()
    	{
    		if(Input.anyKeyDown || Input.mousePosition != prevMousePosition)
    		{
    			StartGameTimer();
    			timeOutWarning.SetActive(false);
    		}
    		prevMousePosition = Input.mousePosition;
    	}
        void StartGameTimer()
    	{
    		CancelInvoke ();
    		Invoke ("ShowRestartWarning", timeUntilRestartWarning);
    	}
        void ShowRestartWarning()
    	{
    		GameObject gameController = GameObject.FindGameObjectWithTag("gc");					// First, find the GameObject
    		CountdownTimer countdownTimer = gameController.GetComponent<CountdownTimer>();		// Then, access the Script in the GameObject
    		countdownTimer.startTimer(countdownLength);											// Finally, call the Script method														
    
    		timeOutWarning.SetActive(true);
    		CancelInvoke ();
    		Invoke ("RestartGame", countdownLength);
    	}
        void RestartGame()
    	{
    		Application.LoadLevel(Application.loadedLevel);
    		Debug.Log("Game Restarted");
    	}
    }
    
    public class CountdownTimer : MonoBehaviour
    {
    	float seconds;
    	public Text timerText;
    
    	public void startTimer(float s)
    	{
    		seconds = s;
    		Update ();
    	}
    
    	public void Update () 
    	{
    		seconds -= Time.deltaTime;
    		timerText.text = seconds.ToString("f0");
    	}
    }
