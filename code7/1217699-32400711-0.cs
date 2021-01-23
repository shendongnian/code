    private List<string> GetList(string property)
    {
        return animals.Select(x => GetProperty(x, property)).ToList();
    }
    
    private static string GetProperty(Animal animal, string property)
    {
    	Type type = typeof(Animal);
    	PropertyInfo propertyInfo = type.GetProperty(property);
    	return (string)propertyInfo.GetValue(animal);
    }
