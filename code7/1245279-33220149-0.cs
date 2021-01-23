        char[] delimiterChars = { ';' };        
        string text = @"Information Technology (IT) > IT Project Management / Team Lead; Information Technology (IT) > IT Management; Information Technology (IT) > Network & System";
        System.Console.WriteLine("Original text: '{0}'", text);
        string[] words = text.Split(delimiterChars);
        System.Console.WriteLine("{0} words in text:", words.Length);
        foreach (string s in words)
        {
            System.Console.WriteLine(s);
        }
