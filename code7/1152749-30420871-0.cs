    public string ToPersianNumber(this string s)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        dictionary.Add("0", "٠");
        dictionary.Add("1", "١");
        dictionary.Add("2", "٢");
        dictionary.Add("3", "٣");
        dictionary.Add("4", "٤");
        dictionary.Add("5", "٥");
        dictionary.Add("6", "٦");
        dictionary.Add("7", "٧");
        dictionary.Add("8", "٨");
        dictionary.Add("9", "٩");
    	dictionary.Aggregate(s, (current, value) => current.Replace(value.Key, value.Value)).ToString();
    }
