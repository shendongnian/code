    private static string[] GetStack(int removeLines)
    {
        string[] stack = Environment.StackTrace.Split(new string[] {Environment.NewLine},
            StringSplitOptions.RemoveEmptyEntries);
        if(stack.Length <= removeLines)
            return new string[0];
        string[] actualResult = new string[stack.Length - removeLines];
        for (int i = removeLines; i < stack.Length; i++)
            //Remove "  at " from the beginning of the line
            actualResult[i - removeLines] = stack[i].Substring(6);
        return actualResult;
    }
