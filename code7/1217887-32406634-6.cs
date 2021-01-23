    public static List<string> SplitArray(string[] strArray)
    {
        List<string> rtnArray = new List<string>();
        foreach (string a in strArray)
        {
            string[] x = a.Split(' ');
            foreach(string b in x)
                rtnArray.Add(b);
        }
        return rtnArray;
    }
