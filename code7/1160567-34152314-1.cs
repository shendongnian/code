    public static Assembly AddReference(string name)
    {
        AssemblyManager.UpdatePath();
        Assembly assembly = null;
        assembly = AssemblyManager.LoadAssemblyPath(name);
        if (assembly == null)
        {
            assembly = AssemblyManager.LoadAssembly(name);
        }
        if (assembly == null)
        {
            string msg = String.Format("Unable to find assembly '{0}'.", name);
            throw new System.IO.FileNotFoundException(msg);
         }
         return assembly ;
    }
