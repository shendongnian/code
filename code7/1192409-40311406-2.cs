    using System.Reflection;
    using Microsoft.CodeDom.Providers.DotNetCompilerPlatform;
    static Lazy<CSharpCodeProvider> CodeProvider { get; } = new Lazy<CSharpCodeProvider>(() => {
        var csc = new CSharpCodeProvider();
        var settings = csc
            .GetType()
            .GetField("_compilerSettings", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(csc);
        var path = settings
            .GetType()
            .GetField("_compilerFullPath", BindingFlags.Instance | BindingFlags.NonPublic);
        path.SetValue(settings, ((string)path.GetValue(settings)).Replace(@"bin\roslyn\", @"roslyn\"));
        return csc;
    });
