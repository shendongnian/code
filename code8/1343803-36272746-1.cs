	public void LaunchGameRunWith(string levelCode, int stars, int diamonds)
		{
		.. analytics
		StartCoroutine(_game( levelCode, superBombs, hearts));
		}
	
	private IEnumerator _game(string levelFileName, int stars, int diamonds)
		{
		// first, add some fake delay so it looks impressive on
		// ordinary modern machines made after 1960
		yield return new WaitForSeconds(1.5f);
		
		AsyncOperation ao;
		ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Gameplay");
		
		// here's exactly how you wait for it to load:
		while (!ao.isDone)
			{
			Debug.Log("loading " +ao.progress.ToString("n2"));
			yield return null;
			}
		
		// here's a confusing issue. in the new scene you have to have
		// some sort of script that controls things, perhaps "NewLap"
		NewLap newLap = Object.FindObjectOfType< NewLap >();
		Gameplay gameplay = Object.FindObjectOfType<Gameplay>();
		
		// this is precisely how you conceptually pass info from
		// say your "main menu scene" to "actual gameplay"...
		newLap.StarLevel = stars;
		newLap.DiamondTime = diamonds;
		
		newLap.ActuallyBeginRunWithLevel(levelFileName);
		}
