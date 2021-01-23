    static bool CheckString(string s)
    {
        var stack = new Stack<char>();
        foreach(char c in s)
            if("([{".Contains(c))
                stack.Push(c);
            else if(")]}".Contains(c))
            {
                if(stack.Count == 0)
                    return false;
                char d = stack.Pop();
                if(d == '(' && c != ')' || d == '[' && c != ']' || d == '{' && c != '}')
                    return false;
            }
        return stack.Count == 0;
    }
