		ParseObject _localPlayer = new ParseObject();
		Task query = _localPlayer.SaveAsync();
		while (!query.IsCompleted)
			yield return null;
		if (!query.IsFaulted && !query.IsCanceled)
		{
			Debug.Log ("Player successfully created!");
		}
		else
		{
			Debug.Log("Failed to create player...");
		}
