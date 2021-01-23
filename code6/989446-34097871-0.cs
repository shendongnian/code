    public static ProgramType ProgramType
    {
        get
        {
            if (!programType.HasValue)
            {
                try
                {
                    if (Type.GetType("Mono.Runtime") != null)
                    {
                        // It's a console application if 'bool Mono.Unix.Native.Syscall.isatty(0)' in Mono.Posix.dll
                        var monoPosix = System.Reflection.Assembly.Load("Mono.Posix, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756");
                        Type syscallType = monoPosix.GetType("Mono.Unix.Native.Syscall");
                        var method = syscallType.GetMethod("isatty");
                        bool isatty = (bool)method.Invoke(null, new object[] { 0 });
                        if (isatty)
                        {
                            programType = ProgramType.MonoConsole;
                        }
                        else
                        {
                            programType = ProgramType.MonoService;
                        }
                    }
                    else
                    {
                        if (Environment.UserInteractive)
                        {
                            programType = ProgramType.WindowsConsole;
                        }
                        else
                        {
                            programType = ProgramType.WindowsService;
                        }
                    }
                }
                catch
                {
                    programType = ProgramType.Unknown;
                }
            }
            return programType.Value;
        }
    }
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool AllocConsole();
    [DllImport("kernel32.dll", SetLastError = true)]
    static extern bool FreeConsole();
    [DllImport("kernel32", SetLastError = true)]
    static extern bool AttachConsole(int dwProcessId);
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
        switch (ProgramType)
        {
            case ProgramType.WindowsConsole:
                {
                    // WindowsConsole application
                    //
                    // Get a pointer to the forground window. The idea here is that
                    // IF the user is starting our application from an existing console
                    // shell, that shell will be the uppermost window. We'll get it
                    // and attach to it
                    IntPtr ptr = GetForegroundWindow();
                    int u;
                    GetWindowThreadProcessId(ptr, out u);
                    try
                    {
                        Process process = Process.GetProcessById(u);
                        if (process.ProcessName == "cmd")
                        {
                            // Is the uppermost window a cmd process?
                            AttachConsole(process.Id);
                        }
                        else
                        {
                            // No console AND we're in console mode ... create a new console.
                            AllocConsole();
                        }
                        // Console is now accessible.
                        NubiloSoft.Util.Logging.Sink.Console.Register();
                        // Arguments?
                        StartConsoleService();
                    }
                    finally
                    {
                        FreeConsole();
                    }
                }
                break;
            case ProgramType.MonoConsole:
                {
                    // Console is now accessible.
                    NubiloSoft.Util.Logging.Sink.Console.Register();
                    // Arguments?
                    StartConsoleService();
                }
                break;
            case ProgramType.MonoService:
            case ProgramType.WindowsService:
                {
                    // Start service
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                        new Service1()
                    };
                    ServiceBase.Run(ServicesToRun);
                }
                break;
            default:
                Console.WriteLine("Unknown CLR detected. Running as console.");
                {
                    // Console is now accessible.
                    NubiloSoft.Util.Logging.Sink.Console.Register();
                    // Arguments?
                    StartConsoleService();
                }
                break;
        }
    }
