        static void Main(string[] args)
        {
            var rsc = RunspaceConfiguration.Create();
            var runSpace = RunspaceFactory.CreateRunspace(rsc);
            runSpace.Open();
            Runspace.DefaultRunspace = runSpace;
            var p = runSpace.CreatePipeline("Get-Process");
            var output = p.Invoke();
            foreach (var o in output)
            {
                Console.WriteLine("{0}", o.Properties["Name"].Value);
            }
        }
