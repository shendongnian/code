    //single space(or)
     string line = "Hello world";
    //double space(or)
    string line = "Hello  world";
    //multiple space(or)
    string line = "Hello     world";
    //multiple Strings
    string line = "Hello world Hello  world";
    //all are working fine
    
                string[] allId = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string finalstr = allId[allId.Length-1];
