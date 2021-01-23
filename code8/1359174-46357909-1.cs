    using System.Management.Automation;
    using System.Management.Automation.Runspaces
    
    private static void AddFolderToQuickAccess(string pathToFolder)
    {
    	using (var runspace = RunspaceFactory.CreateRunspace())
    	{
    		runspace.Open();
    		var ps = PowerShell.Create();
    		var shellApplication =
    			ps.AddCommand("New-Object").AddParameter("ComObject", "shell.application").Invoke();
    		dynamic nameSpace = shellApplication.FirstOrDefault()?.Methods["NameSpace"].Invoke(pathToFolder);
    		nameSpace?.Self.InvokeVerb("pintohome");
    	}
    }
    
    private static void RemoveFolderFromQuickAccess(string pathToFolder)
    {
    	using (var runspace = RunspaceFactory.CreateRunspace())
    	{
    		runspace.Open();
    		var ps = PowerShell.Create();
    		var removeScript =
    			$"((New-Object -ComObject shell.application).Namespace(\"shell:::{{679f85cb-0220-4080-b29b-5540cc05aab6}}\").Items() | Where-Object {{ $_.Path -EQ \"{pathToFolder}\" }}).InvokeVerb(\"unpinfromhome\")";
    
    		ps.AddScript(removeScript);
    		ps.Invoke();
    	}
    }
