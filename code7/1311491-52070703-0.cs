        string AdminUserName = "";
        string AdminPassword = "";
        string MailBoxUserAliasName = "red";
        string MailBoxUserName = "redyellow";
        string MailBoxUserFirstName = "red";
        string MailBoxUserLastName = "yellow";
        string MailBoxUserDisplayName = "red yellow";
        string MailBoxUserMicrosoftOnlineServicesID = "red.yellow@vt0365dev.onmicrosoft.com";
        string MailBoxUserPassword = "P@ssw0rd";
        string MailBoxUserUsageLocation = "IN"; // Set Country of the User
        string MailBoxUserAddLicenses = ""; // Assign Licenses
        
        /// <summary>
        ///  Connect to the PowerShell 
        ///  1. Connect to 365 office with Admin login
        ///  2  Create New MailBox
        ///  3  Set the Country to the user
        ///  3  Set the Country to the user
        ///  4. Assign Licences  to account user
        /// </summary>
        /// <param name="commandFileName"> command file name</param>
        /// <param name="ErrorMessage"> error message</param>
        /// <returns> true or false </returns>
        public bool ConnectPowerShell(string commandFileName, ref string ErrorMessage)
        {
            Program Object_Pro = new Program();
            String input;
            Runspace runspace = null;
            Pipeline pipeline = null;
            PipelineStateInfo info = null;
            try
            {
                if (File.Exists(commandFileName))
                {
                    using (StreamReader sr = File.OpenText(commandFileName))
                    {
                        runspace = RunspaceFactory.CreateRunspace();
                        pipeline = runspace.CreatePipeline();
                        runspace.Open();
                        while ((input = sr.ReadLine()) != null)
                        {
                            //Replace the Peramter Value to original value
                            input = input.Replace("@@username", Object_Pro.AdminUserName);
                            input = input.Replace("@@password", Object_Pro.AdminPassword);
                            input = input.Replace("@@Alias", Object_Pro.MailBoxUserAliasName.ToLower());
                            input = input.Replace("@@Name", Object_Pro.MailBoxUserName.ToLower());
                            input = input.Replace("@@FirstName", Object_Pro.MailBoxUserFirstName.ToLower());
                            input = input.Replace("@@LastName", Object_Pro.MailBoxUserLastName.ToLower());
                            input = input.Replace("@@DisplayName", Object_Pro.MailBoxUserDisplayName.ToLower());
                            input = input.Replace("@@MicrosoftOnlineServicesID", Object_Pro.MailBoxUserMicrosoftOnlineServicesID.ToLower());
                            input = input.Replace("@@UPassword", Object_Pro.MailBoxUserPassword);
                            input = input.Replace("@@UsageLocation", Object_Pro.MailBoxUserUsageLocation);
                            input = input.Replace("@@AddLicenses", Object_Pro.MailBoxUserAddLicenses);
                            pipeline.Commands.AddScript(input);
                        }
                        pipeline.Commands.Add("Out-String");
                        Collection<PSObject> results = pipeline.Invoke();
                        runspace.Close();
                    }
                    info = pipeline.PipelineStateInfo;
                    if (info.State != PipelineState.Completed)
                    {
                        ErrorMessage = info.Reason.ToString();
                        return false;
                    }
                    else
                    {
                        ErrorMessage = "";
                        return true;
                    }
                }
                else
                {
                    ErrorMessage = "File not found";
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        static void Main(string[] args)
        {
            string StrErrorMessage = string.Empty;
            bool ConnectResult;
            // Create Object of Program class
            Program ObjProgram = new Program();
            // File Name Of the PowerShell Command
            string fileName = @"E:\jaimin\Application\ConnectToPowerShell\scriptCreateNewMail.txt";
            string ScriptFileNameForSetLocation = @"E:\jaimin\Application\ConnectToPowerShell\scriptUserlocationset.txt";
            try
            {
                ConnectResult = ObjProgram.ConnectPowerShell(fileName, ref StrErrorMessage);
                if (ConnectResult)
                {
                    ConnectResult = ObjProgram.ConnectPowerShell(ScriptFileNameForSetLocation, ref StrErrorMessage);
                    if (ConnectResult)
                    {
                        Console.WriteLine("task completed");
                    }
                    else
                    {
                        Console.WriteLine(StrErrorMessage);
                    }
                }
                else
                {
                    Console.WriteLine(StrErrorMessage);
                }
            }
            catch (ExitException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
