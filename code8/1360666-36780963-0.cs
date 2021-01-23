    List<string> keyPaths = GetKeyPaths();
    private void DoStuff()
    {        
        // key is disposed when leaving using block
        using(var key = OpenFirstAvailableKey())
        {
            if(key == null)
            {
                // handle error
            }
            
            // do stuff
        }
    }
    
    private RegistryKey OpenFirstAvailableKey()
    {
        RegistryKey result = null;
        try
        {
            foreach(var key in keyPaths)
            {
                result = Registry.LocalMachine.OpenSubKey(key);
                if(result != null)
                {
                    break;
                }
            }    
        }
        catch (System.Exception)
        {
            // handle or throw        
            throw;
        }
            
        return result;
    }
    
    private List<string> GetKeyPaths()
    {
        List<string> paths = new List<string>();
        // Load from db or file or whatever...or just hardcode
        paths.Add("Software\\Wow6432Node\\Company\\Internal\\Product");
        paths.Add("Software\\Company\\Company\\Internal\\Product");
        paths.Add("Software\\Wow6432Node\\Company\\Product");
        paths.Add("Software\\Company\\Product");
        
        return paths;
    }
