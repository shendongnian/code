    async void LoginCheck()
    {
        InitialSessionState iss = InitialSessionState.CreateDefault();
        StringBuilder ss = new StringBuilder();
        ss.AppendLine("some code here")
        using (Runspace runspace = RunspaceFactory.CreateRunspace(iss))
        {
            Collection<PSObject> results = null;
            try
            {
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(ss.ToString());
                results = pipeline.Invoke();
    
            }
            catch (Exception ex)
            {
                results.Add(new PSObject((object)ex.Message));
            }
            finally
            {
                runspace.Close();
                Dispatcher.InvokeAsync(() => {
                    Loading.Visibility = Visibility.Hidden;
                });
                
                if //some stuff
                {
                    //do some things
                }
                else
                {
                    //do some other things
                }
            }
        }
    }
