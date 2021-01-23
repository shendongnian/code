    class CodeMaker {
        static string _codesectionOne = @"
            using Foo.Common.WebService;
            namespace ";
        static string _codesectionTwo = @" {
                class RemoteCaller {
                    static public string Run() {
                        return CallerStuff.FindCallingNameSpace();
                    }
                }
            }";
        public static string CompileAndCall(string targetNamespace, 
                                            string referenceAssembly) {
            CompilerParameters CompilerParams = new CompilerParameters();
            string outputDirectory = Directory.GetCurrentDirectory();
            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";
            string[] references = { "System.dll", referenceAssembly};
            CompilerParams.ReferencedAssemblies.AddRange(references);
            CSharpCodeProvider provider = new CSharpCodeProvider();
            var codeToCompile = _codesectionOne + targetNamespace + _codesectionTwo;
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, 
                                                                         codeToCompile);
            if (compile.Errors.HasErrors) {
                string text = "Compile error: ";
                foreach (CompilerError ce in compile.Errors) {
                    text += "rn" + ce.ToString();
                }
                throw new Exception(text);
            }
            Module module = compile.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;
            if (module != null) {
                mt = module.GetType(targetNamespace + ".RemoteCaller");
            }
            if (mt != null) {
                methInfo = mt.GetMethod("Run");
            }
            if (methInfo != null) {
                return (string)methInfo.Invoke(null, null);
            }
            throw new InvalidOperationException("It's all gone wrong!");
        }
    }
