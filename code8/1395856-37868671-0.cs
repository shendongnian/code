    String word= "Subject: Your Request - 5564 - 1345687974";
    string pat = @"^(Subject)(.*)(- )([0-9]{8,12})$";
    
    Regex r = new Regex(pat, RegexOptions.IgnoreCase);
    Match m = r.Match(word);
    if (m.Groups.Count == 5)
    {
    	word = word.Replace("Subject:", "");
    	String numberInString = m.Groups[4].Value;
    	word = word.Replace(numberInString, "");
    }
