    var listType = l.GetType().GetInterfaces().FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IList<>));
    if (listType != null)
    {
    	Type elementType = listType.GetGenericArguments()[0];
    	var method = this.GetType().GetMethod("doSomethingWithList").MakeGenericMethod(elementType);
    	method.Invoke(this, new object[] { l });
    }
