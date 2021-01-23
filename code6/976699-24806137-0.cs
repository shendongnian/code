        string a = "aaa333aaa333aaa22bb22bb1c1c1c";
        List<string> result = new List<string>();
        int lastSplitInedx = 0;
        for (int i = 0; i < a.Length-1; i++)
        {
            if (char.IsLetter(a[i]) != char.IsLetter(a[i + 1]))
            {
                result.Add(a.Substring(lastSplitInedx, (i + 1) - lastSplitInedx));
                lastSplitInedx = i+1;
            }
            if (i+1 == a.Length-1)
            {
                result.Add(a.Substring(lastSplitInedx));
            }
        }
        foreach (string s in result)
        {
            Console.WriteLine(s);
        }
