        string st = "abc+{(a,b,c),(d,e,f),(r,s+1,t),(u,v,y)}+test-{(a,b),(c,d,e)}+rst+{(a,b),(c,d)}";
        Regex oRegex = new Regex(@"{(\([^)]*\)(,\([^)]*\))*)}");
        foreach (Match mt in oRegex.Matches(st))
        {
            int order = mt.Value
                .TakeWhile(ch => ch != ')')
                .Count(ch => ch == ',') + 1;
            var tuplePattern = string.Join(",", Enumerable.Repeat("[^,)]+", order));
            if (Regex.IsMatch(mt.Value, "{\(" + tuplePattern + "\)(,\("+ tuplePattern +"\))*}"))
            {
                 Console.WriteLine(mt.Value);
            }
        }
    }
