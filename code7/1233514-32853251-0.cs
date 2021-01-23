    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            string pattern = @"(?x)^(\w+-\w+-\w+-\w+)$";
            Regex reg = new Regex(pattern);
            string test = "word-6798-3401-001";
            if((reg.Match(test).Success))
                foreach (var x in test.Split(new char[] {'-'}))
                    Console.WriteLine(x);
        }
    }
