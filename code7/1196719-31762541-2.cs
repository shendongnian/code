    class RunAssembly
    {
        //App domain in which assembly will be loaded
        AppDomain assemblyDomain = null;
        //Load and execute assembly method
        public void LoadAndExecute()
        {
            //Check if appdomain and assembly is already loaded
            if (assemblyDomain != null)
            {
                //unload appDomain and hence the assembly
                AppDomain.Unload(assemblyDomain);
                //Code to download new dll
            }
            assemblyDomain = AppDomain.CreateDomain("assembly1Domain", null);
            assemblyDomain.DoCallBack(() =>
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var pathToDll = @"assembly path";
                        var dllName = "assembly name";
                        var assembly = Assembly.LoadFile(Path.Combine(pathToDll, dllName));
                        var targetAssembly = assembly.CreateInstance("ConsoleApplication2.Program");
                        Type type = targetAssembly.GetType();
                        MethodInfo minfo = type.GetMethod("Main", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                        minfo.Invoke(targetAssembly, null);
                    }
                    catch (Exception ex)
                    {
                        //Log Exception
                    }
                });
            });
        }
    }
