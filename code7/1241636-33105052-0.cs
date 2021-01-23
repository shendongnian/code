            string foo = "Hello!";
            char[] availableSymbols = {'-', ',', '!'};
            char[] availableLetters = {'A', 'a', 'H'}; //etc.
            char[] availableNumbers = {'1', '2', '3'}; //etc
            foreach (char c in foo)
            {
                if (availableLetters.Contains(c)) 
                {
                    // Do what I want with letters
                }
                else if (availableNumbers.Contains(c))
                {
                    // Do what I want with numbers
                }
                else if (availableSymbols.Contains(c))
                {
                    // Do what I want with symbols
                }
            }
