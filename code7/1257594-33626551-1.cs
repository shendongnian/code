    /// <summary>
    /// Gets a runtime added attribute to a type.
    /// </summary>
    /// <typeparam name="TAttribute">The attribute</typeparam>
    /// <param name="type">The type.</param>
    /// <returns>The first attribute or null if none is found.</returns>
    public static TAttribute GetRuntimeAddedAttribute<TAttribute>(this Type type) where TAttribute : Attribute
    {
    	if (type == null) throw new ArgumentNullException(nameof(type));
    
    	var attributes = TypeDescriptor.GetAttributes(type).OfType<TAttribute>();
    	var enumerable = attributes as TAttribute[] ?? attributes.ToArray();
    	return enumerable.Any() ? enumerable.First() : null;
    }
