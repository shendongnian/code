    public IEnumerable<string> Tokenize(Func<string, int> tokenFunc = null)
    {
        IEnumerable<string> tokens = Regex.Split(INPUT, @"(\d+|&|\||\(|\))").Where(x => string.IsNullOrEmpty(x) == false);
        if (tokenFunc != null)
        {
            tokens = tokens.Select(tokenFunc);
        }
    } 
