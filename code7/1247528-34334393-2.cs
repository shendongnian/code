    public class EmsSession
        {
    	static PSCredential cred = (PSCredential)null;
    	static WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri("http://exchangeserver01.my.domain/powershell?serializationLevel=Full"), 
    																		 "http://schemas.microsoft.com/powershell/Microsoft.Exchange", cred);
    																					 
    	public static string GetPropertyValue(this PSObject psObject, string propertyName)
    	{
    		string ret = string.Empty;
    		if (psObject.Properties[propertyName].Value != null)
    			ret = psObject.Properties[propertyName].Value.ToString();
    
    		return ret;
    	}
    	public static List<Lists.ExchangeOverview> ExchOverview()
    	{
    		var data = new List<Lists.ExchangeOverview>();			
    		connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
    		Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo)
    		PowerShell powershell = PowerShell.Create()
    
    		Command cmd1 = new Command("Get-ExchangeServer");
    		powershell.Commands.Commands.Add(cmd1);
    		runspace.Open();
    		powershell.Runspace = runspace;
    		Collection<PSObject> psResults = powershell.Invoke();
    
    		foreach (PSObject psResult in psResults)
    		{
    			data.AddRange(results.Select(obj => new Lists.ExchangeOverview()
    					{
    						Name = psResult.GetPropertyValue("Name"),
    						Edition = psResult.GetPropertyValue("ItemCount"),
    						Version = psResult.GetPropertyValue("AdminDisplayVersion"),
    						Role = psResult.GetPropertyValue("ServerRole"),
    					}));				
    		}
    
    		foreach (ErrorRecord psError in powershell.Streams.Error)
    		{
    			errors.Add(
    				new emsErrorRecord
    				{
    					Command = psError.CategoryInfo.Activity,
    					Reason = psError.CategoryInfo.Reason,
    					Message = psError.Exception.Message
    				});
    		}
    
    		foreach (WarningRecord psWarning in powershell.Streams.Warning)
    		{
    			warnings.Add(
    				new emsWarningRecord
    				{
    					Command = psWarning.InvocationInfo.MyCommand.Name,
    					Message = psWarning.Message
    				});
    		}
    			
    		runspace.Dispose();
    		runspace = null;
    
    		powershell.Dispose();
    		powershell = null;
    		return data;
    	}
    				
    	public static List<Lists.MailboxCount> MailboxDbCounts()
    	{
    		var data = new List<Lists.MailboxCount>();	
    		var databases = DatabaseInformation();
    		connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
    		Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo)
    		PowerShell powershell = PowerShell.Create()
    
    		Command cmd1 = new Command("Get-Mailbox");
    		powershell.Commands.Commands.Add(cmd1);
    		runspace.Open();
    		powershell.Runspace = runspace;
    		Collection<PSObject> psResults = powershell.Invoke();
    
    		foreach (PSObject psResult in psResults)
    		{
    			foreach(Lists.DatabaseInformation database in databases)
    			{
    				int counter = 0;
    				if(database.Name == psResult.GetPropertyValue("Name"))
    				{
    					counter++;
    				}
    				data.Add(new Lists.MailboxCount()
    				{
    					Name = obj.Members["name"].Value.ToString(),
    					Count = counter.ToString()
    				}));
    			}			
    		}
    
    		foreach (ErrorRecord psError in powershell.Streams.Error)
    		{
    			errors.Add(
    				new emsErrorRecord
    				{
    					Command = psError.CategoryInfo.Activity,
    					Reason = psError.CategoryInfo.Reason,
    					Message = psError.Exception.Message
    				});
    		}
    
    		foreach (WarningRecord psWarning in powershell.Streams.Warning)
    		{
    			warnings.Add(
    				new emsWarningRecord
    				{
    					Command = psWarning.InvocationInfo.MyCommand.Name,
    					Message = psWarning.Message
    				});
    		}
    			
    		runspace.Dispose();
    		runspace = null;
    
    		powershell.Dispose();
    		powershell = null;
    	}			
    			
    	public static List<Lists.DatabaseInformation> DatabaseInformation()
    	{
    		var data = new List<Lists.DatabaseInformation>();		
    		connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
    		Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo)
    		PowerShell powershell = PowerShell.Create()
    
    		Command cmd1 = new Command("Get-MailboxDatabase");
    		powershell.Commands.Commands.Add(cmd1);
    		runspace.Open();
    		powershell.Runspace = runspace;
    		Collection<PSObject> psResults = powershell.Invoke();
    
    		foreach (PSObject psResult in psResults)
    		{
    			string edbSize = Functions.BytesToString(new System.IO.FileInfo(obj.Members["EdbFilePath"].Value.ToString()).Length, true);
    			data.AddRange(results.Select(obj => new Lists.MailboxCount()
    					{
    						Name = psResult.GetPropertyValue("Name"),
    						DbSize = edbSize,
    						EdbPath = psResult.GetPropertyValue("EdbFilePath"),
    						LogPath = psResult.GetPropertyValue("LogFolderPath")
    					}));				
    		}
    
    		foreach (ErrorRecord psError in powershell.Streams.Error)
    		{
    			errors.Add(
    				new emsErrorRecord
    				{
    					Command = psError.CategoryInfo.Activity,
    					Reason = psError.CategoryInfo.Reason,
    					Message = psError.Exception.Message
    				});
    		}
    
    		foreach (WarningRecord psWarning in powershell.Streams.Warning)
    		{
    			warnings.Add(
    				new emsWarningRecord
    				{
    					Command = psWarning.InvocationInfo.MyCommand.Name,
    					Message = psWarning.Message
    				});
    		}
    			
    		runspace.Dispose();
    		runspace = null;
    
    		powershell.Dispose();
    		powershell = null;
    	}
    }		
	
