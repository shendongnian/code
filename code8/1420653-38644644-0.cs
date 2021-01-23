    public static PowerShellResponse AddToDistributionGroup(Credentials creds, string groupName, string memberEmail)
    {
        PSCredential cred = new PSCredential(creds.Username, creds.Password.ToSecureString());
    
        WSManConnectionInfo connectionInfo = new WSManConnectionInfo(new Uri(Settings.ExchangeServerAutomationUrl), Settings.ExchangeAutomationSchemaName, cred);
        connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
    
        PSObject group;
    
        using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
        {
            using (PowerShell ps = PowerShell.Create())
            {
                runspace.Open();
                ps.Runspace = runspace;
    
                group =
                        ps
                            .AddCommand("Get-DistributionGroup")
                                .AddParameter("Identity", groupName)
                                .AddParameter("OrganizationalUnit", creds.GetUserDN())
                            .Invoke()
                            .SingleOrDefault();
            }
        }
    
        //can't pipe OU to Add-DistrubtionGroupMember b/c it blows up w/ "null reference exception" when member already exists
        if (group == null)
            return new PowerShellResponse() { Errors = new List<string> { "Group not found." } };
    
        using (Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo))
        {
            using (PowerShell ps = PowerShell.Create())
            {
                runspace.Open();
                ps.Runspace = runspace;
    
                ps.AddCommand("Add-DistributionGroupMember")
                    .AddParameter("Identity", ((dynamic)group).Identity)
                    .AddParameter("Member", memberEmail);
    
                ps.Invoke();
    
                return ps.GetResponse();
            }
        }
    }
