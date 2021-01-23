    string txt="AB-1234562323";
    string re="AB-(\\d+)";	// Integer Number 1
    
     Regex r = new Regex(re,RegexOptions.IgnoreCase|RegexOptions.Singleline);
     Match m = r.Match(txt);
     if (m.Success)// match found
     {
           // get the number 
           String number=m.Groups[1].ToString();  
     }
