    string text = string.Format("{1}{0}{2}{0}\t\t{3}{0}\t\t{4}",
    Environment.NewLine,
     "Split in new lines like this",
     "and in new lines + tabs",
     "like this, in order to have",
     "an array which contains the first line and this second block.");
    
    text.Dump("Before");
    
    var result = Regex.Replace(text, "\r\n\t", "|\t")
                      .Split(new string[] { Environment.NewLine }, StringSplitOptions.None )
                      .Select (rLine => rLine.Replace("|", Environment.NewLine));
    
    result.Dump("after");
 
