    // personally i would change dynamic to object
    // calling code could always cast to dynamic if it needed to
	public dynamic CreateEntity<T>()
	{
		var bllName = typeof(T).Name;
		var efName = bllName.Substring(0, bllName.Length - 2); // removes "Bo"
		var className = string.Concat("Namespace.", efName, ", EfAssembly.dll");
		var efType = Type.GetType(className);
		return efType != null ? Activator.CreateInstance(efType) : null;
	}
