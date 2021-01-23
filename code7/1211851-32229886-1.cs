    // assuming we have string inputStr
    string[] tokens = inputStr.Split ('.');
    if (tokens.Length < 2 || tokens.Length > 2)
    {
        throw new ArgumentException ();
    }
    int feet = int.Parse (tokens[0]);
    int inches = int.Parse (tokens[1]);
    if (inches >= 12)
    {
        throw new ArgumentException ();
    }
    int totalInches = (feet * 12) + inches;
    
