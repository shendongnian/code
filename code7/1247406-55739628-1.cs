      [SetUpFixture]
        public class SetUpTest
        {
            private Process process = null;
            private Process IisProcess = null;
            private System.IO.StreamWriter sw = null;
            string programsFilePath = Environment.GetEnvironmentVariable(@"PROGRAMFILES(X86)");
    
            [OneTimeSetUp]
            public void Initialize()
            {
                //compile web api project
                List<string> commands = new List<string>();
                commands.Add($@"CD {programsFilePath}\MSBuild\14.0\Bin\");
                commands.Add($@"msbuild ""pathToYourSolution.sln"" /t:ProjrctName /p:Configuration=Debug;TargetFrameworkVersion=v4.5 /p:Platform=""Any CPU"" /p:BuildProjectReferences=false /p:VSToolsPath=""{programsFilePath}\MSBuild\Microsoft\VisualStudio\v14.0""");
                RunCommands(commands);
    
                //deploy to iis express
                RunIis();
            }
    
    
    
            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                if (IisProcess.HasExited == false)
                {
                    IisProcess.Kill();
                }
            }
    
            void RunCommands(List<string> cmds, string workingDirectory = "")
            {
                if (process == null)
                {
                    InitializeCmd(workingDirectory);
                    sw = process.StandardInput;
                }
    
                foreach (var cmd in cmds)
                {
                    sw.WriteLine(cmd);
                }
            }
    
            void InitializeCmd(string workingDirectory = "")
            {
                process = new Process();
                var psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                psi.WorkingDirectory = workingDirectory;
                process.StartInfo = psi;
                process.Start();
                process.OutputDataReceived += (sender, e) => { Debug.WriteLine($"cmd output: {e.Data}"); };
                process.ErrorDataReceived += (sender, e) => { Debug.WriteLine($"cmd output: {e.Data}"); throw new Exception(e.Data); };
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
            }
    
            void RunIis()
            {
                string _port = System.Configuration.ConfigurationManager.AppSettings["requiredPort"];
                if (_port == 0)
                {
                    throw new Exception("no value by config setting for 'requiredPort'");
                }
    
                IisProcess = new Process();
                var psi = new ProcessStartInfo();
                psi.FileName = $@"{programsFilePath}\IIS Express\iisexpress.exe";
                psi.Arguments = $@"/path:""pathToRootOfApiProject"" /port:{_port} /trace:error";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.UseShellExecute = false;
                IisProcess.StartInfo = psi;
                IisProcess.Start();
                IisProcess.OutputDataReceived += (sender, e) => { Debug.WriteLine($"cmd output: {e.Data}"); };
                IisProcess.ErrorDataReceived += (sender, e) =>
                {
                    Debug.WriteLine($"cmd output: {e.Data}");
                    if (e.Data != null)
                    {
                        throw new Exception(e.Data);
                    }
                };
                IisProcess.BeginOutputReadLine();
                IisProcess.BeginErrorReadLine();
            }
        }
