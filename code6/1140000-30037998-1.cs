    StringBuilder result = new StringBuilder();
    
    foreach (char c in input)
    {
        result.Append(c);
        if (c != ' ') {
             result.Remove(result.Length - 2, 1);
             result.Append('#');
        }
    }
    string resultAsString = result.ToString();
