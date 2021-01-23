    static bool CheckGuess(char[] secrets, char[] mask, char[] letters, string guess)
    { 
        int misses = 0; bool condition = false;
    
        for (int idx = 0; idx < secret.Length; idx++)
        {
            guess.ToCharArray();
            if (mask[idx] == guess[idx])
            {
                //reveal character or word
                condition = true;
            } 
            else
            {
                misses = misses + 1;
                condition = false;
            }
        }
        return condition;
     }
