    if (j.Equals(leguess))// If the character = the letter guess
    {
        int index = word.IndexOf(j);// Get the index of j
        while (index > -1)
        {
            guess = guess.Remove(index, 1).Insert(index, j.ToString());
            index = word.IndexOf(j, index + 1);
        }
    }
