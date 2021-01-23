    var addMyspace = new List<string>{"!", "...", "\"", ".", ","};
    
    foreach(var s in addMyspace)
    {
         sentence = sentence.Replace(s, string.Format(" {0}",s));
    }
    //split
