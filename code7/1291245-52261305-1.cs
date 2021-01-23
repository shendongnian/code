    Process vsProcess = Process.GetCurrentProcess();
    
    string solutionPath = CurrentWorkspace.CurrentSolution.FilePath;
    
    SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText($@"
                using System;
                using System.Threading.Tasks;
    
                namespace CodeGenApplication
                {{
                    public class Program 
                    {{
                        public static void Main(string[] args) 
                        {{
    
                        Console.ReadLine();
                        int vsProcessId = Int32.Parse(args[0]);
                        CodeGenApp.Test(""{solutionPath.Replace(@"\", @"\\")}"", ""{projectName}"", ""{_codeGenProjectName}"");
                        Console.ReadLine();
                        }}
                    }}
                }}");
    
    string assemblyName = Path.GetRandomFileName();
    
    Project codeGenProject = CurrentWorkspace.CurrentSolution.Projects.Where(x => x.Name == _codeGenProjectName).FirstOrDefault();
    
    List<MetadataReference> references = codeGenProject.MetadataReferences.ToList();
    
    CSharpCompilation compilation = CSharpCompilation.Create(
    
        assemblyName,
        syntaxTrees: new[] { syntaxTree },
        references: references,
        options: new CSharpCompilationOptions(OutputKind.ConsoleApplication));
    
    // Emit assembly to streams.
    EmitResult result = compilation.Emit("CodeGenApplication.exe", "CodeGenApplication.pdb");
    
    if (!result.Success)
    {
        IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
            diagnostic.IsWarningAsError ||
            diagnostic.Severity == DiagnosticSeverity.Error);
    }
    else
    {
        Process codeGenProcess = new Process();
        codeGenProcess.StartInfo.FileName = "CodeGenApplication.exe";
        codeGenProcess.StartInfo.Arguments = vsProcess.Id.ToString();
        codeGenProcess.StartInfo.UseShellExecute = false;
        codeGenProcess.StartInfo.CreateNoWindow = true;
        codeGenProcess.StartInfo.LoadUserProfile = true;
        codeGenProcess.StartInfo.RedirectStandardError = true;
        codeGenProcess.StartInfo.RedirectStandardInput = true;
        codeGenProcess.StartInfo.RedirectStandardOutput = false;
        codeGenProcess.Start();
        foreach (EnvDTE.Process dteProcess in _dte.Debugger.LocalProcesses)
        {
            if (dteProcess.ProcessID == codeGenProcess.Id)
            {
                dteProcess.Attach();
            }
        }
        codeGenProcess.StandardInput.WriteLine("Start");
    }
