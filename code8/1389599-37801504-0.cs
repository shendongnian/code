    /// <summary>
    ///  It seems that if you rename an exe and then try to load said 
    ///  assembly into a separate app-domain, .NET looks for the original
    ///  name.  This class loads the current assembly into the app
    ///  domain manually and then detects request for the original name 
    ///  and redirects it to the correct assembly.
    /// 
    ///  http://stackoverflow.com/questions/37685180
    /// </summary>
    public class RenamedExeFixer : MarshalByRefObject
    {
      /// <summary> Load the assembly that this type is in into the app-domain. </summary>
      public static void LoadOriginatingAssemblyIntoDomain(AppDomain appDomain)
      {
        var pathToSelf = new Uri(typeof(RenamedExeFixer).Assembly.CodeBase).LocalPath;
        appDomain.Load(File.ReadAllBytes(pathToSelf));
        // create an instance of the class inside of the domain
        // so that it can hook into the AssemblyResolve event
        appDomain.CreateInstanceFrom(pathToSelf, typeof(RenamedExeFixer).FullName);
      }
      private readonly string _myAssemblyName;
      public RenamedExeFixer()
      {
        // cached for efficiency (probably not needed)
        _myAssemblyName = typeof(RenamedExeFixer).Assembly.FullName;
        AppDomain.CurrentDomain.AssemblyResolve += HandleAssemblyResolve;
      }
      private Assembly HandleAssemblyResolve(object sender, ResolveEventArgs args)
      {
        if (args.Name == _myAssemblyName)
        {
          return typeof(RenamedExeFixer).Assembly;
        }
        return null;
      }
    }
