    object[] attribs = ReflectedAssembly.GetCustomAttributes(typeof(DebuggableAttribute), 
                                                            false);
    
    // If the 'DebuggableAttribute' is not found then it is definitely an OPTIMIZED build
    if (attribs.Length > 0)
    {
        // Just because the 'DebuggableAttribute' is found doesn't necessarily mean
        // it's a DEBUG build; we have to check the JIT Optimization flag
        // i.e. it could have the "generate PDB" checked but have JIT Optimization enabled
        DebuggableAttribute debuggableAttribute = attribs[0] as DebuggableAttribute;
        if (debuggableAttribute != null)
        {
            HasDebuggableAttribute = true;
            IsJITOptimized = !debuggableAttribute.IsJITOptimizerDisabled;
            BuildType = debuggableAttribute.IsJITOptimizerDisabled ? "Debug" : "Release";
    
            // check for Debug Output "full" or "pdb-only"
            DebugOutput = (debuggableAttribute.DebuggingFlags & 
                            DebuggableAttribute.DebuggingModes.Default) != 
                            DebuggableAttribute.DebuggingModes.None 
                            ? "Full" : "pdb-only";
        }
    }
    else
    {
        IsJITOptimized = true;
        BuildType = "Release";
    }
