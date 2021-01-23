    string pattern = @"(Test1='1' OR) \(Test2 = '2'";
    Match match = Regex.Match(input, pattern);
        if (match.Success)
        {
           foreach(Group group in match.Groups)
           {
               Console.WriteLine(group);
           }
        }
    Console.ReadKey();
