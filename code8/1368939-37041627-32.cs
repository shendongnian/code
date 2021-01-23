    public static bool CheckString(string input)
    {   //Use the closer rather than opener as the key.
        // This will give better lookups when we pop the stack
        var pairs = new Dictionary<char, char>() {
            { '}','{' },  { ']','[' },   { ')','(' }
        }
        var history = new Stack<char>();
        foreach(char c in input)
        {
            if (pairs.ContainsValue(c)) history.Push(c);
            if (pairs.ContainsKey(c) && (history.Count == 0 || history.Pop() != pairs[c]))
                return false;
        }
        return (history.Count == 0);
    }
