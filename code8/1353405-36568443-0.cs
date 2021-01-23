    public static void Main(string[] args)
    {
        IRuntimeEnvironment runtime = PlatformServices.Default.Runtime;
        IApplicationEnvironment env = PlatformServices.Default.Application;
        Console.WriteLine($@"
    IApplicationEnvironment:
            Base Path:      {env.ApplicationBasePath}
            App Name:       {env.ApplicationName}
            App Version:    {env.ApplicationVersion}
            Runtime:        {env.RuntimeFramework}
    IRuntimeEnvironment:
            OS:             {runtime.OperatingSystem}
            OS Version:     {runtime.OperatingSystemVersion}
            Architecture:   {runtime.RuntimeArchitecture}
            Path:           {runtime.RuntimePath}
            Type:           {runtime.RuntimeType}
            Version:        {runtime.RuntimeVersion}");
    }
