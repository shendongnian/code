    private void LoadAssem(){
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    //use File.ReadAllBytes to avoid assembly locking
        Assembly asm2 = Assembly.Load(File.ReadAllBytes("AssemblyPath"));
        }
