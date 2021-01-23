    private static bool ContainsOnlyLetters(string str)
    {
        foreach (char c in str)
        {
            if (!char.IsLetter(c))
                return false;
        }
        return true;
    }
