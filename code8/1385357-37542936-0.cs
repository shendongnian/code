    public static void OpenSlnFile(string file)
    {
    	System.Type type = Type.GetTypeFromProgID("VisualStudio.DTE.9.0");
    	EnvDTE.DTE dte = (EnvDTE.DTE)System.Activator.CreateInstance(type);
    	dte.MainWindow.Visible = true;
    
    	dte.Solution.Open(file);
    }
