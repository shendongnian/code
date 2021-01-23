    private static bool HasSpecialCharacter(string s, char[] specialCharacters)
    {
        foreach (char specialCharacter in specialCharacters)
        {
            if (s.Contains(specialCharacter))
            {
                return true;
            }
        }
        return false;
    }
