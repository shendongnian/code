    private static IEnumerable<string> RandomStrings(
        string allowedChars,
        int minLength,
        int maxLength,
        Random rng)
    {
        char[] chars = new char[maxLength];
        int setLength = allowedChars.Length;
    
        int length = rng.Next(minLength, maxLength + 1);
    
            for (int i = 0; i < length; ++i)
            {
                chars[i] = allowedChars[rng.Next(setLength)];
            }
    
            return new string(chars, 0, length);
    }
