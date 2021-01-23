    internal void YourDesiredMethodName (string[] input)
    {
        foreach (string s in input.Where(w => patterns.Contains(w)))
        {
            s="";
            for(i=0;i<s.Split(' ').Count();i++)
                s += "NN";
        }
    }
