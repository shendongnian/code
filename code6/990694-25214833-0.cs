	foreach (char j in wordchar)// Iterate through every character
	{
		if (j.Equals(leguess))// If the character = the letter guess
		{
			int index = word.IndexOf(j);// Get the index of j
			guess = guess.Remove(index, 1).Insert(index, j.ToString());
		}
	}
