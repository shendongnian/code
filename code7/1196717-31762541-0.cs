    class RunAssembly
    {
        //App domain in which assembly will beloaded
        AppDomain assemblyDomain = null;
        //Load and execute assembly method
        public void LoadAndExecute()
        {
            var pathToDll = "yourdllpath";
            var dllName = "yourdllname";
            //Check if appdomain and assembly is already loaded
            if (assemblyDomain != null)
            { 
                //unload appDomain and hence the assembly
                AppDomain.Unload(assemblyDomain);
            }
            //Create new appdomain and load assembly in it
            AppDomainSetup domainSetup = new AppDomainSetup { PrivateBinPath = pathToDll };
            assemblyDomain = AppDomain.CreateDomain("assembly1Domain", null, domainSetup);
            Task.Factory.StartNew(ad =>
            {
                try
                {
                    var obj = ((AppDomain)ad).CreateInstanceFromAndUnwrap(dllName, "myclass.Program");
                    Type type = obj.GetType();
                    MethodInfo minfo = type.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic |
                              BindingFlags.Static | BindingFlags.Instance);
                    minfo.Invoke(obj, null);
                }
                catch (Exception ex)
                {
                    //Log Exception
                }
            }, assemblyDomain);
        }
    }
