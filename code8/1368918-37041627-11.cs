    public static bool CheckString(string input)
    {
        var pop = new Dictionary<char, char>() {
            { '}','{' },  { ']','[' },   { ')','(' }
        }
        var push = new List<char> {'{','[', '('};
        var history = new Stack<char>();
        foreach(char c in input)
        {
            if (push.Contains(c)) history.Push(c);
            if (pop.ContainsKey(c) && (history.Count == 0 || history.Pop() != pop[c]))
                return false;
        }
        return (history.Count == 0);
    }
