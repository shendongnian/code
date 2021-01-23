     string str = "Hello# , how are you?";
     string newstr = "";
     //Checks for last character is special charact
     var regexItem = new Regex("[^a-zA-Z0-9_.]+");
     //remove last character if its special
     if (regexItem.IsMatch(str[str.Length - 1].ToString()))
     {
       newstr =   str.Remove(str.Length - 1);            
     }
     string replacestr = Regex.Replace(newstr, "[^a-zA-Z0-9_]+", "-");
