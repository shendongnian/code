    Type[] types = null;
    try
    {
        types = assembly.GetTypes();
    }
    catch (ReflectionTypeLoadException e)
    {
        types = e.Types;
        StringBuilder strErrors = new StringBuilder();
        foreach (Exception exError in e.LoaderExceptions)
        {
            //Message errors can appear several times.
            if (!strErrors.ToString().Contains(exError.Message))
            {
                 strErrors.Append(exError.Message);
                 Exception innerError = exError.InnerException;
                 while (innerError != null)
                 {
                     strErrors.Append(innerError.Message);
                     innerError = innerError.InnerException;
                 }
            }
        }
        //trace the error
    }
    if (types != null)
    {
        foreach (Type a_type in types)
        {
             //handle types in here
        }
    }
