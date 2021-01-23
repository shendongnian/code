    object payload = new A { Id = 1 };
    object value = TryGetPropertyValue(payload, "Id", "Name"); //returns 1
    payload = new B { Name = "foo" };
    value = TryGetPropertyValue(payload, "Id", "Name"); //returns "foo"
.
    public object TryGetPropertyValue(object obj,  params string[] propertyNames)
    {
        foreach (var name in propertyNames)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(name);
            if (propertyInfo != null) return propertyInfo.GetValue(obj);
        }
        throw new ArgumentException();
    }
