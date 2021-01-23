    private bool MatchesPattern(string test)
    {
        int idx = 0;
        // test are letters
        for (int steps = 1; steps <= 3; steps++)
        {
            if (!char.IsLetter(test[idx++])) return false;
        }
        // test are numbers
        for (int steps = 1; steps <= 3; steps++)
        {
            if (!char.IsNumber(test[idx++])) return false;
        }
        // test are letters
        for (int steps = 1; steps <= 2; steps++)
        {
            if (!char.IsLetter(test[idx++])) return false;
        }
        // test last char is number
        if (!char.IsNumber(test.Last())) return false;
 
        return true;
    }
