    const string _regExp = @"-\d{4}-\d{2}-\d{2}T\d{4}\.txt$";
    Regex _regex = new Regex(_regExp);
    
    public bool validateFileExpression(string fileName)
    {
        return _regex.IsMatch(fileName);
    }
