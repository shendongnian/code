    string input = "blablablabla@User;\\u0004User\username,blablablablablablablabla@User;\\u0004User\anotherusername,@Viewblablablablablablablabla";
    List<string> userNames = new List<string>();
    foreach (Match match in Regex.Matches(input, @"(u0004User\\)(.*?),", RegexOptions.IgnoreCase))
       {
         string currentUserName = match.Groups[2].ToString();        
         userNames.Add(currentUserName);    // Add UserName to List 
       }
