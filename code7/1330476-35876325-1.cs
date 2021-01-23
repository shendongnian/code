    var parentProcessID = GetParentProcessID();
    var parentProcess = parentProcessID.HasValue ? Process.GetProcessById(parentProcessID.Value) : null;
    
    if(parentProcess != null)
    {
        try
        {
            var strongName = Assembly.ReflectionOnlyLoadFrom(parentProcess.MainModule.FileName);
            // check your strong name to make sure it belongs to the launcher...
        }
        catch (System.BadImageFormatException e)
        {
            throw;
        }
    }
