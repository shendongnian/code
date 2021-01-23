    var typenames = new[] { "String", "Object", "Int32" };
    var types =  Assembly.GetAssembly(typeof(object))
    	.GetTypes()
    	.Where(type => typenames.Contains(type.Name))
        .ToArray(); // A Type[] containing System.String, System.Object and System.Int32
