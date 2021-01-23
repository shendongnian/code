    public IEnumerable<string> ChangedFields<T>(T first, T second)
    {
        if (obj1.GetType() != obj2.GetType())
            throw new ArgumentOutOfRangeException("Objects should be of the same type");
        var properties = first
    		.GetType()
    		.GetProperties();
    		
        foreach (var property in properties)
        {
            if(!object.Equals(property.GetValue(first), property.GetValue(second)))
    		{
                yield return property.Name;
    		}
        }
    }
