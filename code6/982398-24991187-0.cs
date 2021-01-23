    public class HomeController : Controller
    {
        public Assembly AssemblyA { get; set; }
        public Assembly AssemblyB { get; set; }
        public ActionResult Index()
        {
            var provider = new CSharpCodeProvider();
            var parametersA = new CompilerParameters();
            parametersA.GenerateInMemory = true;
            parametersA.OutputAssembly = "dynamicA.dll";
            var code1 = @"namespace DynamicA {  public class DynamicClassA  {  } }";
            var result1 = provider.CompileAssemblyFromSource(parametersA, code1);
            this.AssemblyA = result1.CompiledAssembly;
            var parametersB = new CompilerParameters();
            parametersA.GenerateInMemory = true;
            parametersB.ReferencedAssemblies.Add("dynamicA.dll");
            parametersB.OutputAssembly = "dynamicB.dll";
            var code2 = @"using DynamicA; namespace DynamicB { public class DynamicB { public DynamicClassA MyProperty { get; set; } } }";
            var results2 = provider.CompileAssemblyFromSource(parametersB, code2);
            this.AssemblyB = results2.CompiledAssembly;
            AppDomain.CurrentDomain.AssemblyResolve += (sender, e) =>
            {
                if (e.Name.Contains("dynamicA"))
                    return this.AssemblyA;
                if (e.Name.Contains("dynamicB"))
                    return this.AssemblyB;
                return null;
            };
            AppDomain.CurrentDomain.Load(this.AssemblyA.FullName);
            AppDomain.CurrentDomain.Load(this.AssemblyB.FullName);
            var t = results2.CompiledAssembly.DefinedTypes.First();
            var pi = t.GetProperty("MyProperty");
             var res = pi.PropertyType.Name;
            
            return View(res);
        }
    }
