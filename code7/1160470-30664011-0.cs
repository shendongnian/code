    public static DateTime GetDate(string stringFormat)
    {
        var date = stringFormat.Split(' ')[0].Split('.').Select(x => Int32.Parse(x)).ToArray();
        return new DateTime(date[2], date[1], date[0]);
    }
