    using app = CompanyName.AppName.Application;
    ...
    using (Runspace rs = RunspaceFactory.CreateRunspace()) {
        rs.ThreadOptions = PSThreadOptions.UseCurrentThread;
        rs.Open();
        rs.SessionStateProxy.SetVariable("app", typeof(app)); 
    
        using (PowerShell ps = PowerShell.Create()) {
            ps.Runspace = rs;
    
            ps.AddScript("$app::DocumentManager");
            ps.Invoke();
        }
        rs.Close();
    }
