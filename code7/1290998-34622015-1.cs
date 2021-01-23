    List<string> valueList = new List<string>();
  	string listNameKey = key;
    string regex = "" + listNameKey + ":" + "\"(?<" + 
            listNameKey.Replace(" ","") + ">[^\"]*)\""; // Removing spaces in the group name here
	var matches = Regex.Matches(contents, regex, RegexOptions.Singleline);
    foreach (Match match in matches)
    {
        if (match.Success)
        {                    
            string value = match.Groups[key.Replace(" ", "")].Value; // Removing spaces here
            valueList.Add(value);
        }            
    }
