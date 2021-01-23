    private bool SearchProperties<T>(T part, string searchString) where T : Part
    {
        var props = typeof(T).GetProperties();
        foreach (var prop in props)
        {
            var value = prop.GetValue(part);
            if (value is IEnumerable)
            {
                // special handling for collections
            }
            else if(value != null)
            {
                string valueString = value.ToString();
                if (string.Equals(valueString, searchString))
                    return true;
            }
        }
        return false;
    }
