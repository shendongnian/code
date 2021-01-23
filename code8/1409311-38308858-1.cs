    var typenames = new[] { "String", "Object", "Int32" };
    var types =  typeof(object).GetTypeInfo().Assembly
    	.GetTypes()
    	.Where(type => typenames.Contains(type.Name))
        .ToArray(); // A Type[] containing System.String, System.Object and System.Int32
