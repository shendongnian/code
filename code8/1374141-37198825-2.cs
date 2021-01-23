    static void Main(string[] args)
    {
      AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(MyAssemblyLoadEventHandler);
      System.Data.DataColumn d = new System.Data.DataColumn();
      Console.ReadLine();
    }
    static void MyAssemblyLoadEventHandler(object sender, AssemblyLoadEventArgs args)
    {
      Console.WriteLine("ASSEMBLY LOADED: " + args.LoadedAssembly.FullName);
      string loadedAssemblyFullName = args.LoadedAssembly.FullName;
      foreach (System.Reflection.Assembly parent in AppDomain.CurrentDomain.GetAssemblies())
      {
        System.Reflection.AssemblyName[] referencedAssemblies = parent.GetReferencedAssemblies();
        string[] referencedFullNames = (from r in referencedAssemblies select r.FullName).ToArray();
        if (referencedFullNames.Contains(loadedAssemblyFullName))
        {
          Console.WriteLine(System.IO.Path.GetFileName(args.LoadedAssembly.CodeBase) +
                            " was referenced by " +
                            System.IO.Path.GetFileName(parent.CodeBase));
        }
      }
    }
