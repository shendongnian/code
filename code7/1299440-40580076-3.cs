    public static IScriptExecutor<T, R> CreateExecutor<T, R>(AppDomain appDomain, string script)
        {
            var t = typeof(ScriptExecutor<T, R>);
            var executor = (ScriptExecutor<T, R>)appDomain.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName, false, BindingFlags.CreateInstance, null, 
                new object[] {script, null, true}, CultureInfo.CurrentCulture, null);
            return executor;
        }
    public static AppDomain CreateSandbox()
    {
        var setup = new AppDomainSetup { ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase };
        var appDomain = AppDomain.CreateDomain("Sandbox", null, setup, AppDomain.CurrentDomain.PermissionSet);
        return appDomain;
    }
    string script = @"int Square(int number) {
                          return number*number;
                      }
                      Square(Args)";
            
    var domain = CreateSandbox();
    var executor = CreateExecutor<int, int>(domain, script);
    using (var src = new RemoteCompletionSource<int>())
    {
        executor.Execute(5, src);
        Console.WriteLine($"{src.Task.Result}");
    }
