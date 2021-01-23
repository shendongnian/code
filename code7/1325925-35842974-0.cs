    var assembly = Assembly.GetExecutingAssembly();
    var resourceName = "CustomActions.Resources.common_base.dll";
    
    byte[] bytes = null;
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    {
    	if (stream != null)
    	{
    		session.InfoLog("dll found was in resources");
    
    		bytes = new byte[(int)stream.Length];
    		stream.Read(bytes, 0, (int)stream.Length);
    	}
    }
    
    if (bytes != null)
    {
    	// save file here!
    	File.WriteAllBytes(destPath, bytes);
    }
