    private string GetUsername(int sessionID)
            {
                try
                {
                    Runspace runspace = RunspaceFactory.CreateRunspace();
                    runspace.Open();
    
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript("Quser");
                    pipeline.Commands.Add("Out-String");
    
                    Collection<PSObject> results = pipeline.Invoke();
    
                    runspace.Close();
    
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (PSObject obj in results)
                    {
                        stringBuilder.AppendLine(obj.ToString());
                    }
    
                    foreach (string User in stringBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Skip(1))
                    {
                        string[] UserAttributes = User.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
    
                        if (UserAttributes.Length == 6)
                        {
                            if (int.Parse(UserAttributes[1].Trim()) == sessionID)
                            {
                                return UserAttributes[0].Replace(">", string.Empty).Trim();
                            }
                        }
                        else
                        {
                            if (int.Parse(UserAttributes[2].Trim()) == sessionID)
                            {
                                return UserAttributes[0].Replace(">", string.Empty).Trim();
                            }
                        }
                    }
    
                }
                catch (Exception exp)
                {
                    // Error handling
                }
    
                return "Undefined";
            } 
