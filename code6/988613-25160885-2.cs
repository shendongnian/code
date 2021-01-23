    static void Main(string[] args) {
      var domain = AppDomain.CreateDomain("MailChimpDomain");
      domain.AssemblyResolve +=new ResolveEventHandler(domain_AssemblyResolve);
      domain.DoCallBack(() => {
        string path = @"MyAssembly.dll";
        var assembly = AppDomain.CurrentDomain.Load(path);
      });
    }
    static Assembly domain_AssemblyResolve(object sender, ResolveEventArgs args) {
      byte[] rawAssembly = File.ReadAllBytes(Path.Combine(@"c:\MyAssemblyPath", args.Name));
      return Assembly.Load(rawAssembly);
    }
