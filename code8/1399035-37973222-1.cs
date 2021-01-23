    public string[] wantedServices = { "MSSQL$AMTECHFASTTEST", "SQLBrowser" };
    public void stopService()
    {
        ServiceController[] services = ServiceController.GetServices()
                                          .Where(svc => wantedServices.Contains(svc.ServiceName))
                                          .ToArray();
        try
        {
            foreach (ServiceController svc in services)
            {
                MessageBox.Show($"{svc.ServiceName} {svc.Status}", "Service Status");                    
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error");
        }
    }
