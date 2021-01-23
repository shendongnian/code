    string pattern = "\D\d{2}$"
    date.Replace(pattern, LongDate);
    string LongDate(string value)
    {
        string seperator = value.Substring(0,1);
        value = value.Substring(1,2);
        if(int32.Parse(value) < int32.Parse(DateTime.Now.Year.ToString().Substring(value.Length -2, 2))
            return seperator + DateTime.Now.Year.ToString().Substring(0, value.Length -2) + value;
        return seperator + (DateTime.Now.Year - 100).ToString().Substring(0, value.Length -2) + value;
    }
