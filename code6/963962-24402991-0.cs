    private String GetName(string variable, string label, string dimension)
    {
        StringBuilder result = new StringBuilder();
        bool bEmpty = true;
        if (!String.IsNullOrEmpty(label)
        {
            result.Append(label);
            result.Append(' ');
        }
        if (!String.IsNullOrEmpty(dimension)
        {
            result.Append('[');
            result.Append(dimension);
            result.Append("] ");
        }
        if (!String.IsNullOrEmpty(variable)
        {
            result.Append('(');
            result.Append(dimension);
            result.Append(") ");
        }
        if (result.Count > 0)
        {
           result.Length := result.Length - 1;
        }
        return result.ToString();
    }
