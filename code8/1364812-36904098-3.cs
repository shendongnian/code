    //...other code
    static bool CheckLetter(string questionedChar)
    {
        bool decision = false;
        foreach(char c in questionedChar)
        {
            if(!char.IsLetter(c))
            {
                decision = false;
                throw new NonLetterException(c);
            }
            else
            {
                decision = true;
            }
        }
        return decision;
    } 
    //...other code
