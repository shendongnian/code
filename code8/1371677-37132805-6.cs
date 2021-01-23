    // you can create this class in another project and
    // make assembly .because you need a copy of it in 
    //folder that you set for ApplicationBase of second AppDomain
    public class AssemblyLoader : MarshallByRefObject
    {
        AssemblyLoader()
        {
             AppDomain.CurrentAppDomain.AssemblyResolve += LoaddependencyOfAssembly;
        }
    public void LoaddependencyOfAssembly(object sender,)
    {
        //load depdency of your assembly here
        // if you has replaced those dependencies  to folder that you set for ApplicationBase of second AppDomain doesn't need do anything here
    }
    public Assembly asm {get;set;}
    public void LoadAssembly(MemoryStream ms)
    {
         asm=  Assembly.Load(ms.ToArray());
    }
    }
