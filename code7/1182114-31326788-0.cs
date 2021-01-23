	private string MyMethod(string propName)
	{
		PropertyInfo pi = typeof (MyClass).GetProperty(propName);
		if (pi == null)
			return null;
		var a = (NowThatsAnAttribute)pi.GetCustomAttribute(typeof(NowThatsAnAttribute));
		if (a!=null)
			return a.HeresMyString;
		return null;
	}
