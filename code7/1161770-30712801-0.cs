    void NextGuess()
	{
		guess = Random.Range (min,max);
		while(used.Contains(guess))
			guess = Random.Range (min,max);
		used.Add (guess);
		text.text = guess.ToString ();
		maxGuessesAllowed = maxGuessesAllowed - 1;
		if (maxGuessesAllowed <= 0) {
			Application.LoadLevel ("Win");
		}
	}
