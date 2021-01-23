    internal DateTime ParseDateString(string dateString)
    {
        DateTime myDateTime;
        var attempt1 = doSomeRegex(dateString);
        if (DateTime.TryParse(attempt1, out myDateTime))
        {
            return myDateTime;
        }
        var attempt2 = anotherRegex(dateString);
        if (DateTime.TryParse(attempt2, out myDateTime))
        {
            return myDateTime;
        }
        var attempt3 = lastChanceRegex(dateString);
        if (DateTime.TryParse(attempt3, out myDateTime))
        {
            return myDateTime;
        }
        throw new ArgumentException($"Error parsing date string: {dateString}", nameof(dateString));
    }
