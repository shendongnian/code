    class Program
    {
        private static void Main(string[] args) {
            new ScriptRunner().Run();   
            Console.ReadKey(); 
        }        
    }
    class ScriptRunner {
        public ScriptRunner() {
            this.LogReporter = new LogReporter();
        }
        public void Run() {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.ThreadOptions = PSThreadOptions.UseCurrentThread;
            runspace.Open();
            
            
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript("$RunningInstances=@(Get-ChildItem | Where-Object {$_.InstanceStatus -eq \"Running\"})");
            runspace.SessionStateProxy.SetVariable("LogReporter", this.LogReporter);
            pipeline.Commands.AddScript("$LogReporter.ReportProgress($RunningInstances.Count.ToString()+\" instances running currently...\")");
            StringBuilder builder = new StringBuilder();
            Collection<PSObject> objects = pipeline.Invoke();            
        }
        public LogReporter LogReporter { get; private set; }
    }
    class LogReporter
    {
        public void ReportProgress(string msg)
        {
            Console.WriteLine(msg);
        }
    }
