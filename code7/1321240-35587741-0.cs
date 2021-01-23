        string[] words = File.ReadAllText(path).Split(',');
        foreach (string s in words)
        {
            System.Console.WriteLine(s);
        }
