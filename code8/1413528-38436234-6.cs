    protected bool IsNullValue(string fieldName)
    {
        try
        {
            object value = Eval(fieldName);
            return Convert.IsDBNull(value) || value == null || value.ToString() == string.Empty;
        }
        catch
        {
            return true;
        }
    }
