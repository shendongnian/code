    // assuming we have string InputStr
    string[] Tokens = InputStr.Split ('.');
    if (Tokens.Length < 2 &&
        Tokens.Length > 2)
    {
        throw new ArgumentException ();
    }
    int Feet = int.Parse (Tokens[0]);
    int Inches = int.Parse (Tokens[1]);
    if (Inches >= 12)
    {
        throw new ArgumentException ();
    }
    int TotalInches = (Feet * 12) + Inches;
    
