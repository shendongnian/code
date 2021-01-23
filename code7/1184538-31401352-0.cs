    using (StreamReader sr = new StreamReader(@"saverisbex"))
    {
        int lineNumber = 0;
        string line;
        while((line = sr.ReadLine()) != null)
        {
            int groupOf8 = lineNumber / 8;
            // ...
            lineNumber++;
        }
    }
