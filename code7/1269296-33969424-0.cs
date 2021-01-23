        string s1 = "/TEST/TEST123";
        string s2 = "/TEST1/Test/Test/Test/";
        string s3 = "/Text/12121/1212/";
        string s4 = "/121212121/asdfasdf/";
        string s5 = "12345";
        string pattern = @"\/?[a-zA-Z0-9]+\/?";
        
        Console.WriteLine(Regex.Matches(s1, pattern)[0]);
        Console.WriteLine(Regex.Matches(s2, pattern)[0]);
        Console.WriteLine(Regex.Matches(s3, pattern)[0]);
        Console.WriteLine(Regex.Matches(s4, pattern)[0]);
        Console.WriteLine(Regex.Matches(s5, pattern)[0]);
