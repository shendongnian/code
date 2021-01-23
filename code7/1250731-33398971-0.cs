        string username = "username";
        using (PowerShell PowerShellInstance = PowerShell.Create())
        {
            PowerShellInstance.AddScript("param ([string]$user); add-pssnapin 'Microsoft.Exchange.Management.PowerShell.Admin';" +
                "get-mailbox -Identity $user -resultsize unlimited | select Name -expand EmailAddresses | Select SmtpAddress;");
            PowerShellInstance.AddParameter("user", username);
            Collection<PSObject> PSOutput = PowerShellInstance.Invoke();
            if (PowerShellInstance.Streams.Error.Count > 0)
            {
                foreach (var error in PowerShellInstance.Streams.Error)
                {
                    //for reading errors in debug mode
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(error.Exception.Message);
                    sb.AppendLine(error.Exception.InnerException.Message);
                    sb.AppendLine(error.CategoryInfo.Category.ToString());
                    sb.AppendLine(error.CategoryInfo.Reason);
                    sb.AppendLine(error.ErrorDetails.Message);
                    sb.AppendLine(error.ErrorDetails.RecommendedAction);
                    Console.WriteLine(sb.ToString());
                }
            }
            if (PSOutput.Count > 0)
            {
                foreach (var item in PSOutput)
                {
                    Console.WriteLine(item);
                }
            }
        }
