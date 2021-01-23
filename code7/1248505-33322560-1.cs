    static void Main(string[] args)
    {
    
        var propertyInfo = GetPropertyInfo(typeof(A), "PropA.PropC");
        Console.WriteLine(propertyInfo.Name);
        Console.ReadLine();
    }
    
    static PropertyInfo GetPropertyInfo(Type type, string propertyChain)
    {
        if (!propertyChain.Contains("."))
        {
            var lastProperties = type.GetProperties().Where(m => m.Name.Equals(propertyChain));
            return lastProperties.Any() ? lastProperties.First() : null;
        }
    
        var startingName = propertyChain.Split('.')[0];
        var found = type.GetProperties().Where(m => m.Name.Equals(startingName));
        return found.Any() ? GetPropertyInfo(found.First().PropertyType, propertyChain.Replace(startingName + ".", "")) : null;
    }
