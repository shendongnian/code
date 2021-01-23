    public List<ParameterValues> Convert(List<ParameterValues> values)
    {
        var newValues = new List<ParameterValues>();
    
        foreach (var val in values)
        {
            if (val.Parameter.Type == "Int")
            {
                newValues.Add(new IntValue(val));
            }
        }
    
        return newValues;
    }
