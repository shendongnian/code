    void Start () {
		Canvas_PauseMenu = Canvas_PauseMenu.GetComponent<Canvas> ();
		Button_Pause = Button_Pause.GetComponent<Button> ();
		Button_Resume = Button_Resume.GetComponent<Button> ();
		Canvas_PauseMenu.enabled = false;
		Button_Resume.enabled = false;
		Button_Resume.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	public void PauseTest () {
		if(!active){
			PauseGame();
		}
		else{
			ResumeGame();
		}
	}
	public void BackToMainMenu()
	{
		Application.LoadLevel (0);
	}
	public void PauseGame()
	{
		Canvas_PauseMenu.enabled = true;
		Button_Exit.enabled = true;
		Button_Pause.enabled = false;
		Button_Pause.gameObject.SetActive (false);
		Button_Resume.enabled = true;
		Button_Resume.gameObject.SetActive (true);
		active = true;
		Time.timeScale = 0;
	}
	public void ResumeGame()
	{
		Canvas_PauseMenu.enabled = false;
		Button_Exit.enabled = false;
		Button_Pause.enabled = true;
		Button_Pause.gameObject.SetActive (true);
		Button_Resume.enabled = false;
		Button_Resume.gameObject.SetActive (false);
		active = false;
		Time.timeScale = 1;
	}
