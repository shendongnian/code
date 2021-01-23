    private CSharpCodeProvider CodeProvider
    {
        get
        {
            if(codeProvider == null)
            {
                var csc = new CSharpCodeProvider();
                try
                {
                    var settings = csc.GetType().GetField("_compilerSettings", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(csc);
                    var path = settings.GetType().GetField("_compilerFullPath", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(settings) as string;
                    settings.GetType().GetField("_compilerFullPath", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(settings, path.Replace(@"bin\roslyn\", @"roslyn\"));
                }
                catch { }
                codeProvider = csc;
            }
            return codeProvider;
        }
    }
    CSharpCodeProvider codeProvider;
