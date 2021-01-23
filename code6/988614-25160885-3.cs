    static void Main(string[] args) {
      var domain = AppDomain.CreateDomain("MailChimpDomain");
      domain.AssemblyResolve +=new ResolveEventHandler(domain_AssemblyResolve);
      domain.DoCallBack(() => {
        string path = @"MyAssembly.dll";
        var assembly = AppDomain.CurrentDomain.Load(path);
        // to do something with the assembly
        var type = assembly.GetType("MailChimp.MailChimpManager");
        var ctor = type.GetConstructor(new[] { typeof(string) });
        var mc = ctor.Invoke(new object[] { "111111111111222f984b9b1288ddf6f0" });        
      });
    }
    static Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args) {
      byte[] rawAssembly = File.ReadAllBytes(Path.Combine(@"c:\MyAssemblyPath", args.Name));
      return Assembly.Load(rawAssembly);
    }
