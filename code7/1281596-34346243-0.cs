    var typeSelector = new Dictionary<Type, Action<PropertyInfo>>()
    {
        {typeof(int), IntAction }
        {typeof(string), StringAction }
        {typeof(DateTime), DateTimeAction }
    };
