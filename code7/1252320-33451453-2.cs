    private char? FirstRepeatedCharacter(string input)
    {
        var knownCharacters = new HashSet<char>();
        for (var i = 0; i < input.Length; ++i)
        {
            // Add returns true when the value is new, false when the value already exists in the hashset.
            if (!knownCharacters.Add(input[i]))
            {
                return input[i];
            }
        }
        return null;
    }
