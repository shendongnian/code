        string[] sequ1 = { "abcde", "fghi", "jkl", "mnop", "qrs", };
        string[] sequ2 = { "abc", "defgh", "ijklm", "nop", };
        
        IEnumerable<IEnumerable<string>> result = sequ1.Select(n1 => sequ2.Where(n2 => n1.Length < n2.Length));
        foreach (IEnumerable<string> y in result)
        {
            foreach (string z in y)
            {
                Console.WriteLine(z);
            }
        }
