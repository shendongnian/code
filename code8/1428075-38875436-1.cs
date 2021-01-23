	public dynamic CreateEntity<T>()
	{
		var bllName = typeof(T).Name;
		var efName = bllName.Substring(0, bllName.Length - 2); // removes "Bo"
		var className = string.Concat("Namespace.", efName, ", EfAssembly.dll");
		var efType = Type.GetType(className);
		return efType != null ? Activator.CreateInstance(efType) : null;
	}
