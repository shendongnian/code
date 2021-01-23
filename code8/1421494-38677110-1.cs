	public void LaunchSoundboard()
		{
		StartCoroutine(_soundboard());
		}
	private IEnumerator _soundboard()
		{
		Grid.music.Duck();
		
		yield return new WaitForSeconds(.2f);
		
		AsyncOperation ao;
		ao = UnityEngine.SceneManagement
           .SceneManager.LoadSceneAsync("YourSceneName");
		
		while (!ao.isDone)
			{
			yield return null;
			}
		
		// here, the new scene IS LOADED
		SoundBoard soundBoard = Object.FindObjectOfType<SoundBoard>();
		if(soundBoard==null) Debug.Log("WOE!");
		soundBoard.SomeFunctionInSoundboardScript();
		}
---
	public static void FadeOut(this Graphic g)
		{
		g.GetComponent<CanvasRenderer>().SetAlpha(1f);
		g.CrossFadeAlpha(0f,.15f,false);
		}
	
