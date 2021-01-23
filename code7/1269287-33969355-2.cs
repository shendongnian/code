    public string functionName(string input)
    {
        if(input.Contains('/'))
        {
            string SplitStr = input.Split('/')[1];
            return "/"+SplitStr .Substring(0, 1) +SplitStr.Substring(1).ToLower()+"/"
        }
        return input;
    }
