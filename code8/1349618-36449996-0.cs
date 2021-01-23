	//Secure String
    
	string pwd = "Password";
	char[] cpwd = pwd.ToCharArray();
	SecureString ss = new SecureString();
	foreach (char c in cpwd)
	ss.AppendChar(c);
	//URI
    
	Uri connectTo = new Uri("http://exchserver.domain.local/PowerShell");
	string schemaURI = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
	//PS Credentials
    
	PSCredential credential = new PSCredential("Domain\\administrator", ss);
	WSManConnectionInfo connectionInfo = new WSManConnectionInfo(connectTo, schemaURI, credential);
	connectionInfo.MaximumConnectionRedirectionCount = 5;
	connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
	Runspace remoteRunspace = RunspaceFactory.CreateRunspace(connectionInfo);
	remoteRunspace.Open();
	PowerShell ps = PowerShell.Create();
	ps.Runspace = remoteRunspace;
	ps.Commands.AddCommand("Get-Mailbox");
	ps.Commands.AddParameter("Identity","user@domain.local");
	foreach (PSObject result in ps.Invoke()) 
	{
	Console.WriteLine("{0,-25}{1}", result.Members["DisplayName"].Value,
	result.Members["PrimarySMTPAddress"].Value);
	}
      
