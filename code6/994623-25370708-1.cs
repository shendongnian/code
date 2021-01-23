    // Console application ConsoleApplication.exe
    // dependency on Production.dll, Usage.dll and Simulation.dll
    namespace ConsoleApplication {
      internal class AssemblyResolver : MarshalByRefObject {
        static internal void Register(AppDomain domain) {
          var resolver = domain.CreateInstanceFromAndUnwrap(
            Assembly.GetExecutingAssembly().Location,
                typeof(AssemblyResolver).FullName) as AssemblyResolver;
          resolver.RegisterDomain(domain);
        }
        private void RegisterDomain(AppDomain domain) {
          domain.AssemblyResolve += ResolveAssembly;
        }
        private Assembly ResolveAssembly(object sender, ResolveEventArgs args) {
          var assemblyName = new AssemblyName(args.Name);
          string name = assemblyName.Name;
          // comment out line below and you'll load "Production" instead
          if (name == "Production") {
            name = "Simulation";
          }
          var fileNames = new[] { name + ".dll", name + ".exe" };
          foreach (string fileName in fileNames) {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (File.Exists(path)) {
              return Assembly.Load(File.ReadAllBytes(path));
            }
          }
          return null;
        }
      }
      class Program {
        static void Main(string[] args) {
          var domain = AppDomain.CreateDomain("Doable", null, new AppDomainSetup {
            DisallowApplicationBaseProbing = true
          });
          AssemblyResolver.Register(domain);
          domain.DoCallBack(() => {
            // writes out "Simulation"
            new Usage.TestUsage().Do();
          });
        }
      }
    }
   
