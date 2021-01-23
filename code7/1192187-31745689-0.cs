    public static ClrRuntime CreateRuntimeHack(this DataTarget target, string dacLocation, int major, int minor)
    {
        string dacFileNoExt = Path.GetFileNameWithoutExtension(dacLocation);
        if (dacFileNoExt.Contains("mscordacwks") && major == 4 && minor >= 5)
        {
            Type dacLibraryType = typeof(DataTarget).Assembly.GetType("Microsoft.Diagnostics.Runtime.DacLibrary");
            object dacLibrary = Activator.CreateInstance(dacLibraryType, target, dacLocation);
            Type v45RuntimeType = typeof(DataTarget).Assembly.GetType("Microsoft.Diagnostics.Runtime.Desktop.V45Runtime");
            object runtime = Activator.CreateInstance(v45RuntimeType, target, dacLibrary);
            return (ClrRuntime)runtime;
        }
        else
        {
            return target.CreateRuntime(dacLocation);
        }
    }
