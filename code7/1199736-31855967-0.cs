    var obj = new List<int>(); // new SerializableDictionary<string, int>();
    var type = obj.GetType();
    var dictType = typeof(SerializableDictionary<,>);
    bool b = type.IsGenericType && 
             dictType.GetGenericArguments().Length == type.GetGenericArguments().Length &&
             type == dictType.MakeGenericType(type.GetGenericArguments());
