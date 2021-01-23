    internal void YourDesiredMethodName (string[] input)
    {
        foreach (string s in input.Where(w => patterns.Contains(w)))
        {
            s="";
            for(i=0;i<s.Split(' ').Count();i++)
            {
                if(i+1==s.Split(' ').Count())
                    s += "NN";
                else 
                    s += "NN ";
            }
        }
    }
