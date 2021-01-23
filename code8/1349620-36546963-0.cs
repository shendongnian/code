     public class ExchangeShellExecuter
    {
        public Collection<PSObject> ExecuteCommand(Command command)
        {
            RunspaceConfiguration runspaceConf = RunspaceConfiguration.Create();
            PSSnapInException PSException = null;
            PSSnapInInfo info = runspaceConf.AddPSSnapIn("Microsoft.Exchange.Management.PowerShell.E2010", out PSException);
            Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConf);
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.Add(command);
            Collection<PSObject> result = pipeline.Invoke();
            return result ;
        }
    }
    public Command NewMailBox(string userLogonName,string firstName,string lastName,string password
            ,string displayName,string organizationUnit = "mydomain.com/Users", 
            string database = "Mailbox Database 1338667540", bool resetPasswordOnNextLogon = false)
        {
            try
            {
                SecureString securePwd = ExchangeShellHelper.StringToSecureString(password);
                Command command = new Command("New-Mailbox");
                var name = firstName + " " + lastName;
                command.Parameters.Add("FirstName", firstName);
                command.Parameters.Add("LastName", lastName);
                command.Parameters.Add("Name", name);
                command.Parameters.Add("Alias", userLogonName);
                command.Parameters.Add("database", database);
                command.Parameters.Add("Password", securePwd);
                command.Parameters.Add("DisplayName", displayName);
                command.Parameters.Add("UserPrincipalName", userLogonName+ "@mydomain.com");
                command.Parameters.Add("OrganizationalUnit", organizationUnit);
                //command.Parameters.Add("ResetPasswordOnNextLogon", resetPasswordOnNextLogon);
                return command;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Command AddEmail(string email, string newEmail)
        {
            try
            {
                Command command = new Command("Set-mailbox");
                command.Parameters.Add("Identity", email);
                command.Parameters.Add("EmailAddresses", newEmail);
                command.Parameters.Add("EmailAddressPolicyEnabled", false);
                return command;
            }
            catch (Exception)
            {
                throw;
            }
            //
        }
        public Command AddSetDefaultEmail(string userEmail, string emailToSetAsDefault)
        {
            try
            {
                Command command = new Command("Set-mailbox");
                command.Parameters.Add("Identity", userEmail);
                command.Parameters.Add("PrimarySmtpAddress", emailToSetAsDefault);
                
                return command;
            }
            catch (Exception)
            {
                throw;
            }
            //PrimarySmtpAddress
        }
