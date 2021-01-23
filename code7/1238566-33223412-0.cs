    public void GenerateFaxFile(string Daftar_No, string Channelno,
                string NationalCode, Action<CSPFEnumration.ProcedureResult> result)
            {
                ThreadPool.QueueUserWorkItem(o =>
                {
                    string script = "your script";
                    try
                    {
                        // more of your script
                        
                        // I want to make a pause in here without locking UI
                        while (true)
                        {
                            // do your check here to unpause
                            if (stopMe == true)
                            {
                                break;
                            }
    
                            Thread.Sleep(500);
                        }
    
    
                        if (File.Exists(FaxFilePath))
                        {
                            result(CSPFEnumration.ProcedureResult.Success);
                            return;
                        }
                        else
                        {
                            result(CSPFEnumration.ProcedureResult.Error);
                        }
    
    
                    }
                    catch (Exception ex)
                    {
                        InternalDatabase.GetInstance.InsertToPensionOrganizationException(ex);
                        result(CSPFEnumration.ProcedureResult.Error);
                        return;
                    }
    
                });
    
            }
    
            public void HowToUseMe()
            {
                GenerateFaxFile("", "", "", result => {
    
                    if (result == CSPFEnumration.ProcedureResult.Error)
                    {
                        // no good
                    }
                    else
                    {
                        // bonus time
                    }
                });
            }
