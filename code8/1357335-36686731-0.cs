    static char ExtractString(string test)
    {
        return test.SkipWhile(c => Char.IsLetter(c))
                   .SkipWhile(c => Char.IsDigit(c))
                   .FirstOrDefault();
    }
