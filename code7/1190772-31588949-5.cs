    public static bool StartHi(string str)
    {
        bool firstHi;    
        if(string.IsNullOrEmpty(str))
        {
            Console.WriteLine("The string is empty!");
        }
        else if (System.Text.RegularExpressions.Regex.Match(str, @"^hi\b").Success))
        {        
            firstHi = true;
            Console.WriteLine("The string starts with \"hi\"");
        }
        else
        {
            firstHi = false;
            Console.WriteLine("The string doesn't start with \"hi\"");
        }
        Console.ReadLine();
        return firstHi;
    }
