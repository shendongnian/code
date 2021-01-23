    public static string ParseTemplate(string template, string username, string senderName)
    {
    	template = Regex.Replace(template, @"<<USER>>", username);
    	return Regex.Replace(template, @"<<SENDER>>", senderName);
    }
