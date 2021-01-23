    var asm = System.Reflection.Assembly.LoadFrom("External.Resources.dll");
    string[] strings = asm.GetManifestResourceNames();
    
    foreach (var s in strings)
    {
        var rm = new ResourceManager(s, asm);
    
        // Get the fully qualified resource type name
        // Resources are suffixed with .resource
        var rst = s.Substring(0, s.IndexOf(".resource"));
        var type = asm.GetType(rst, false);
    
        // if type is null then its not .resx resource
        if (null != type)
        {
            var resources = type.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var res in resources)
            {
                // collect string type resources
                if (res.PropertyType == typeof(string))
                {
                    // get value from static property
                    string myResourceString = res.GetValue(null, null) as string;
                }
            }
        }
    
    }  
          
