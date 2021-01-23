    public DB Where(string field, string operat, string value, string andOr, string field2, string operat2, string value2)
    {
        var inputs = new string[] {field, operat, value, andOr, field2, operat2, value2};
        foreach(var input in inputs)
        {
            Throw.IfNullOrEmpty(input, nameof(input)));
        }
    }    
