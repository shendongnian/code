    PegColour[] CheckPegs(PegColour[] userGuess, PegColour[] generated)
    {
        bool[] matched = new bool[userGuess.Length];
        List<PegColour> result = new List<PegColour>();
        // Look for exact matches
        for (int i = 0; i < userGuess.Length; i++)
        {
            if (userGuess[i] == generated[i])
            {
                result.Add(PegColour.Red);
                matched[i] = true;
            }
        }
        if (result.Count != userGuess.Length)
        {
            // Look for colour matches in wrong position
            for (int i = 0; i < userGuess.Length; i++)
            {
                if (!matched[i])
                {
                    for (int j = 0; j < generated.Length; j++)
                    {
                        if (!matched[j] && userGuess[i] == generated[j])
                        {
                            result.Add(PegColour.White);
                            matched[j] = true;
                        }
                    }
                }
            }
        }
        return result.ToArray();
    }
