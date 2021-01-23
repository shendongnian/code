       public App():base()
        {
            //*****This is used to tell the application how to load DLLs
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveHandler.ResolveEventHandler);
        }
