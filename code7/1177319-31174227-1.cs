    public List<string> Sort(List<string> theList, char theChar)
    {
        List<string> output = new List<string>();
        foreach(string s in theList)
        {
            if (s.StartsWith(theChar.ToString()))
            {
                output.Add(s);
            }
        }
        
        return output;
    }
