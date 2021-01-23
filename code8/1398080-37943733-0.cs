    using (ServiceController service= new ServiceController("WebClient"))
        {
           
            if (service.Status == ServiceControllerStatus.Stopped)
            {
                
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 15));
                //Check status here by calling service.Status and proceed with your code.
            }
            else
            {
              //proceed with your code as the service is up and running
            }
        }
