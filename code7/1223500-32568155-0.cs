    var key = @"[HKEY_LOCAL_MACHINE\SOFTWARE\4YourSoul\Server\ReportEMailService\OrderConfirmation_SynergyWorldInc]";
    
                 key = key.Replace("[", string.Empty);
                 key = key.Replace("]", string.Empty);
                 var splitkeys =key.Split('\\');
    
                if (splitkeys.Any())
                {
                    string result = splitkeys.Last();
                }
