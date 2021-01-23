    ...
	myDynamic.A = "A";
    
    // get settable public properties of the type
	var props = currentType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(x => x.GetSetMethod() != null);
    // create an instance of the type
	var obj = Activator.CreateInstance(currentType);
    // set property values using reflection
	var values = (IDictionary<string,object>)myDynamic;
	foreach(var prop in props)
		prop.SetValue(obj, values[prop.Name]);
