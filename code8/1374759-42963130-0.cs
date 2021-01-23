    Type t = null;
    
    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
    {
        try
        {
            foreach (Type type in a.GetTypes())
            {
                if (type.FullName == clientEx.ExceptionType)
                {
                    t = type;
                    break;
                }                                            
            }
    
            if (t != null)
                break;
        }
        catch (Exception) { }
    }
