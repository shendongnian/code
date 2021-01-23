	public object Invoke(object instance, object[] inputs, out object[] outputs)
	{
		outputs = new object[0];
		// This is the 'Type' object you have in the generic Invoker class
		Type interfaceType = typeof(IESFPingable);
		FieldInfo[] fields = serviceType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
		foreach (FieldInfo f in fields)
		{
			if (interfaceType.IsAssignableFrom(f.FieldType))
			{
			    ///////ADDED THIS
				if( HttpContext.Current.ApplicationInstance is NinjectHttpApplication)
				{
					NinjectHttpApplication ninjectApp = HttpContext.Current.ApplicationInstance as NinjectHttpApplication;
					var obj = ninjectApp.Kernel.Get(f.FieldType);
					((IESFPingable)obj).Ping();
				}
			}
		}
		return DateTime.Now; //temporary
	}
