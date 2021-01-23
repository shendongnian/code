    string s = Console.ReadLine();
    int victimCount;
    if(Int32.TryParse(s, NumberStyles.Integer, 
                      CultureInfo.CurrentCulture,
                      out victimCount))
    {
       // Your value is a valid int.
    }
