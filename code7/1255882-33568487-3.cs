    string input = "blablablabla@User;\\u0004User\\username,blablablablablablablabla@User;\\u0004User\\anotherusername,@Viewblablablablablablablabla";
    List<char[]> userNameStringArrays = new List<char[]>();
    foreach (Match match in Regex.Matches(input, @"(u0004User\\)(.*?),", RegexOptions.IgnoreCase))
       {
         string currentUserName = match.Groups[2].ToString();        
         userNameStringArrays.Add(currentUserName.ToCharArray());    // Add to List with UserNames (as Char[])
       }
