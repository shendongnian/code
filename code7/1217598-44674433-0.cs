    public static Assembly CurrentDomain_BindingRedirect(object sender, ResolveEventArgs args)
    {
        var name = new AssemblyName(args.Name);
        switch (name.Name)
        {
            case "Microsoft.Graph.Core":
                return typeof(Microsoft.Graph.IBaseClient).Assembly;
    
            case "Newtonsoft.Json":
                return typeof(Newtonsoft.Json.JsonSerializer).Assembly;
    
            case "System.Net.Http.Primitives":
                return Assembly.LoadFrom("System.Net.Http.Primitives.dll");
    
            default:
                return null;
        }
    }
