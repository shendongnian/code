    string input = "TEXT+TEXT";
    List<string> allAllowed = new List<string>() { "+", "-", "TEXT", @"\s" };
    
    //In case of having allowed words sharing common parts (e.g., TEXT & SUBTEXT), 
    //you would have to order the list by word-length to avoid problems
    //allAllowed = allAllowed.OrderByDescending(x => x.Length).ToList();
    
    string outString = input;
    foreach (string allowed in allAllowed)
    {
        outString = outString.Replace(allowed, "");
    }
    
    bool inputIsValid = (outString == "");
