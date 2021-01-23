    public static void Main(string[] args)
    {
        var a = IsOctal("023"); //true
        var b = IsOctal("678"); //false
    }
    public static bool IsOctal(string text)
    {
        //get a collection of chars that each text element can be
        var possibleChars = Enumerable.Range(0, 8)
            .Select(x => x.ToString()[0]);
        //"are there any chars in 'text' that are not in 'possibleChar'?"
        var anyAreInvalid = text
            .Where(x => !possibleChars.Contains(x))
            .Any();
        //return the inverse of your question
        return !anyAreInvalid;
    }
