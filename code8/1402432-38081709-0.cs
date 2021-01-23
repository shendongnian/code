    public bool MyTryParse(string dateString, out DateTime dt)
    {
        dt = new DateTime();
        if (dateString == null)
            return false;
        if (dateString.Length > 3)
                return false;
        return DateTime.TryParse(dateString, CultureInfo.CurrentCulture, DateTimeStyles.None, out dt);            
    }
