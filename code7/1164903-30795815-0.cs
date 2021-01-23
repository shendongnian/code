    char[] delimiterChars = { ':' };
    string[] words = result.Split(delimiterChars);
    foreach (string s in words)
        {
            System.Console.WriteLine(s);
        }
