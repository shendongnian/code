    public static string ToInfix (List<string> postfix_input)
    {
        // Make a one-to-one copy of a list:
        List<string> postfix_working = new List<string>();
        foreach (string token in postfix_input)
        {
            postfix_working.Add(token);
        }
        // Then do stuff...
        //(...)
    }
