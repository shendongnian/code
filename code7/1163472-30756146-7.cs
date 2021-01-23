    public static string ReplaceCaseInsensitive(string original, string pattern, string replacement, bool keepOriginalCase = false)
    {
        int count, position0, position1;
        count = position0 = position1 = 0;
        int replacementIndexOfPattern = replacement.IndexOf(pattern, StringComparison.OrdinalIgnoreCase);
        if (replacementIndexOfPattern == -1)
            keepOriginalCase = false; // not necessary
        int inc = (original.Length / pattern.Length) *
                  (replacement.Length - pattern.Length);
        char[] chars = new char[original.Length + Math.Max(0, inc)];
        bool[] upperCaseLookup = new bool[pattern.Length];
        while ((position1 = original.IndexOf(pattern, position0, StringComparison.OrdinalIgnoreCase)) != -1)
        {             
            // first part that will not be replaced
            for (int i = position0; i < position1; ++i)
                chars[count++] = original[i];
            // remember the case of each letter in the found patter that will be replaced
            if (keepOriginalCase)
            {
                for (int i = 0; i < pattern.Length; ++i)
                    upperCaseLookup[i] = Char.IsUpper(original[position1 + i]);
            }
            // The part that will be replaced:
            for (int i = 0; i < replacement.Length; ++i)
            {
                // only keep case of the relevant part of the replacement that contains the part to be replaced
                bool lookupCase = keepOriginalCase 
                    && i >= replacementIndexOfPattern
                    && i < replacementIndexOfPattern + pattern.Length;
                char newChar = replacement[i];
                if (lookupCase)
                {
                    bool wasUpper = upperCaseLookup[i - replacementIndexOfPattern];
                    bool isUpper = Char.IsUpper(newChar);
                    if (wasUpper && !isUpper)
                        newChar = Char.ToUpperInvariant(newChar);
                    else if (!wasUpper && isUpper)
                        newChar = Char.ToLowerInvariant(newChar);
                }
                else
                {
                    newChar = replacement[i];
                }
                chars[count++] = newChar;
            }
            position0 = position1 + pattern.Length;
        }
        if (position0 == 0) 
            return original;
        // the rest
        for (int i = position0; i < original.Length; ++i)
            chars[count++] = original[i];
        return new string(chars, 0, count);
    }
