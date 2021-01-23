    ServiceController[] mySc = ServiceController.GetServices();
    bool startedServiceCorrect = false;
    foreach (ServiceController sc in mySc)
    {
        if (sc.DisplayName == "myservice")
        {
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                if (sc.ServiceType != (ServiceType.InteractiveProcess | ServiceType.Win32OwnProcess)) 
                {
                    startedServiceCorrect = sc.ChangeServiceConfiguration(0, (ServiceType.InteractiveProcess | ServiceType.Win32OwnProcess));
                }
                try
                {
                    sc.Start();
                }
                catch
                { 
                
                    startedServiceCorrect = false;
                }
            }
            break;
        }
    }
