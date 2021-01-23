    DateTime dateValue;
    bool tryParseAttempt = DateTime.TryParse(mat.ToString(), out dateValue);
    if(!tryParseAttempt)
    {
        throw new ArgumentException(string.Format("Cannot parse value to DateTime.  '{0}'", mat.ToString());
    }
