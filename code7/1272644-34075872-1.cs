    string input = "t1126".Replace("t", "");
    string pattern = "hhmm";
    DateTime dt;
    
    DateTime.TryParseExact(input, pattern, null,                                  
        DateTimeStyles.None, out dt);
    Console.WriteLine(dt.ToString("h:m tt")); //outputs 11:26 AM
    
    string reverse = String.Format("t{0}",dt.ToString("hhmm"));
    Console.WriteLine(reverse); //outputs t1126
