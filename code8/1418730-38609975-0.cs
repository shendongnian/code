    private static void Main(string[] args)
          {
             // All this does is dispatch the call to a new process, so that the build can complete independently
             // before attempting to update the keepForever field
             // This is because you cannot update this field while the build is running
    
             if (args.Length < 1)
             {
                throw new Exception("No Build Number Provided");
             }
    
             var buildId = args[0];
    
             Console.WriteLine("Dispatching task to retain build: " + buildId);
    
             var workingDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    
             Console.WriteLine("Working Directory Set: " + workingDir);
    
             if (workingDir == null)
             {
                throw new Exception("Working directory is null");
             }
    
             var p = new Process
             {
                StartInfo =
                {
                   WorkingDirectory = workingDir,
                   FileName = "RetainBuildIndefinitely.exe",
                   Arguments = buildId,
                   RedirectStandardOutput = false,
                   UseShellExecute = true,
                   CreateNoWindow = false
                }
             };
             p.Start();
          }
