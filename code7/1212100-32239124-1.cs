	public void CallFunction(Type type, string methodToCall, params object[] args)
	{
		// Why this part is so complex? Do I miss something?
	    //var constructedType = typeof (MethodCaller<>).MakeGenericType(type);
	    //dynamic target = Activator.CreateInstance(constructedType);
		var target = Activator.CreateInstance(type);
		var result = type.InvokeMember(method_name, System.Reflection.BindingFlags.InvokeMethod, null, target, args);
        // ... do something with result if you need ...
	}
