    public string[] service = { "MSSQL$AMTECHFASTTEST", "SQLBrowser" };
    public void stopService()
    {
        int i = 0;
        ServiceController[] scServices = ServiceController.GetServices()
                                          .Where(svc => service.Contains(svc.ServiceName)
                                          .ToArray();
        try
        {
            foreach (ServiceController svc in scServices)
            {
                MessageBox.Show($"{svc.ServiceName} {services.Status}", "Service Status");                    
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error");
        }
    }
