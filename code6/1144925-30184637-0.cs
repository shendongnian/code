    public List<string> getAllProperties(Func<MyItem, string> func)
    {
        List<string> output = new List<string>();
        foreach (MyItem item in getItems())
        {
            string value = func(item);
            if (!output.Contains(value) &&
                value != null)
            {
                output.Add(value);
            }
        }
        return output;
    }
