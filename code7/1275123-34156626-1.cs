    string resourceName = "SomeNameSpace.SomeFile.xsd";
    Assembly assembly = Assembly.GetExecutingAssembly();
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    {
        if ( stream == null )
    	    throw new ArgumentException("resource not found", "resourceName");
    	using (StreamReader reader = new StreamReader(stream))
    	{
    		string result = reader.ReadToEnd();
    		return result;
    	}
    }
