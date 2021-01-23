    // Use reflection to create the action, invoking the method below.
	var setAction = (Action<object>) this.GetType()
        .GetMethod("CastAction", BindingFlags.Static | BindingFlags.NonPublic)
        .MakeGenericMethod(prop.PropertyType)
        .Invoke(null, new object[]{setMethod});
    // invoke the action like this:
    object value = 42; // or any value of the right type.
    setAction(value);
