        static void Main(string[] args)
        {
            try
            {
    #if DEBUG
                int index = Array.FindIndex(args, x => x.Equals("LAUNCHDEBUGGER", StringComparison.OrdinalIgnoreCase));
                if (index > -1)
                {
                    System.Diagnostics.Debugger.Launch();
                }
    #endif
-----------------
     <LaunchInfo>
        <ImagePath>C:\SomeFolder\SomeConsoleApp.exe</ImagePath>
        <CmdLineArgs>myCommandLineArg1 LAUNCHDEBUGGER</CmdLineArgs>
        <WorkDir>C:\SomeFolder\</WorkDir>
      </LaunchInfo>
