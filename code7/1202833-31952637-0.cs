    static void Main(string[] args)
    {
        var uninstallProcess = System.Diagnostics.Process.Start("msiexec", "/uninstall http://MyServer/MyApp.msi");
        uninstallProcess.WaitForExit();
        Console.WriteLine("after uninstall");
        var installProcess = System.Diagnostics.Process.Start("msiexec", "/i http://myServer/MyApp_new.msi");
	    installProcess.WaitForExit();
        Console.WriteLine("after install");
	
        Console.ReadLine();
    }
