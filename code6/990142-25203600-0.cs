     public ClassName()
     {
         var currentWorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
         string path = Path.Combine(cwd, @"HereGoesYourRelativeFilepath");
         SetDllDirectory(path);
     }
