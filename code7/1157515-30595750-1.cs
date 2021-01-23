        public static void ServiceMonitor()
        {
            for (;;)
            {
                // Monitor the CagService
                ServiceController myService = new ServiceController();
                myService.ServiceName = "CagService";
                string svcStatus = myService.Status.ToString();
                // If the CagService is running, add to the log and sleep for 5 minutes
                try
                {
                    if (svcStatus == "Running")
                    {
                        Library.WriteErrorLog("AEM Service is running! Sleeping for 5 minutes...");
                    }
                    // If the service is stopped, add to the log file and attempt a restart
                    else if (svcStatus == "Stopped")
                    {
                        Library.WriteErrorLog("WARNING: AEM Service is stopped! Attempting to start the AEM service...");
                        myService.Start();
                        string svcStatusWas = "";
                        while (svcStatus != "Running")
                        {
                            if (svcStatus != svcStatusWas)
                            {
                                Library.WriteErrorLog("Status: " + svcStatus);
                            }
                            svcStatusWas = svcStatus;
                            myService.Refresh();
                            svcStatus = myService.Status.ToString();
                        }
                        Library.WriteErrorLog("AEM Service has been started! Sleeping for 5 minutes...");
                    }
                    // If the service has any other status, stop it then restart it. 
                    else
                    {
                        myService.Stop();
                        Library.WriteErrorLog("Status: " + svcStatus);
                        while (svcStatus != "Stopped")
                        {
                            myService.Refresh();
                            svcStatus = myService.Status.ToString();
                        }
                        Library.WriteErrorLog("WARNING: AEM Service is stopped! Attempting to start the AEM service...");
                    }
                }
                catch(InvalidOperationException)
                {
                    Library.WriteErrorLog("Invalid Operation Exception! The service cannot be started because it is disabled.");
                }
                System.Threading.Thread.Sleep(300000);
            }
        }
