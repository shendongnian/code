    internal static AssemblyName CreateAssemblyName(
               String assemblyString, 
               bool forIntrospection, 
               out RuntimeAssembly   assemblyFromResolveEvent)
    {
            if (assemblyString == null)
               throw new ArgumentNullException("assemblyString");
            Contract.EndContractBlock();
 
            if ((assemblyString.Length == 0) ||
                (assemblyString[0] == '\0'))
                throw new ArgumentException(Environment.GetResourceString("Format_StringZeroLength"));
 
            if (forIntrospection)
                AppDomain.CheckReflectionOnlyLoadSupported();
 
            AssemblyName an = new AssemblyName();
 
            an.Name = assemblyString;
            an.nInit(out assemblyFromResolveEvent, forIntrospection, true); // This method may internally invoke AssemblyResolve event.
            
            return an;
