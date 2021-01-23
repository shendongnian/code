        Runspace runSpace = RunspaceFactory.CreateRunspace();
        runSpace.Open();
        PSSnapInException psex;
        runSpace.RunspaceConfiguration.AddPSSnapIn("Citrix.Broker.Admin.V2", out psex);
        Pipeline pipeline = runSpace.CreatePipeline();
        Command getSession = new Command("Get-BrokerSession");
        getSession.Parameters.Add("AdminAddress", "SERVERNAME");
        pipeline.Commands.Add(getSession);
        Collection<PSObject> output = pipeline.Invoke();
