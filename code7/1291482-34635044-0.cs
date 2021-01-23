    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    private static WSManConnectionInfo _connectionInfo;
    static void Main(string[] args)
    {
        string userName = "DOMAIN\\User";
        string password = "UserPassowrd";
        PSCredential psCredential = new PSCredential(userName, GenerateSecureString(password));
        _connectionInfo = new WSManConnectionInfo(
                new Uri("http://server.domain.local/PowerShell"),
                "http://schemas.microsoft.com/powershell/Microsoft.Exchange", psCredential);
        _connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
            
        Console.WriteLine(GetPrimarySmtpAddressBy("FirstnameLastname@company.com");
    }
    public static string GetPrimarySmtpAddressBy(string identity)
        {
            using (Runspace runspace = RunspaceFactory.CreateRunspace(_connectionInfo))
            {
                using (PowerShell powerShell = PowerShell.Create())
                {
                    powerShell.AddCommand("Get-Mailbox");
                    powerShell.AddParameter("Identity", identity);
                    runspace.Open();
                    powerShell.Runspace = runspace;
                    PSObject psObject = powerShell.Invoke().FirstOrDefault();
                    if (psObject != null && psObject.Properties["PrimarySmtpAddress"] != null)
                        return psObject.Properties["PrimarySmtpAddress"].Value.ToString();
                    else return "";
                }
            }
        }
    public static System.Security.SecureString GenerateSecureString(string input)
        {
            System.Security.SecureString securePassword = new System.Security.SecureString();
            foreach (char c in input)
                securePassword.AppendChar(c);
            securePassword.MakeReadOnly();
            return securePassword;
        }
