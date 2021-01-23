        public System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        string path = Variables.LibPath.ToString();
        if (args.Name.Contains("System.Web.Helpers"))
        {
            return System.Reflection.Assembly.UnsafeLoadFrom(System.IO.Path.Combine(path, "System.Web.Helpers.dll"));
        }
        return null;
    }
    /// <summary>
    /// This method is called once, before rows begin to be processed in the data flow.
    /// </summary>
    public override void PreExecute()
    {
        base.PreExecute();
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    }
...
