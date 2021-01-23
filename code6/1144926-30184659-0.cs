    public List<string> GetAll(Func<MyItem, string> propertyGetter)
    {
        List<string> output = new List<string>();
        foreach (MyItem item in getItems())
        {
            var value = propertyGetter(item);
            if (!output.Contains(value) && value != null)
            {
                output.Add(value);
            }
        }
        return output;
    } 
