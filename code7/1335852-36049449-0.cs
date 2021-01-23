     static public void Main()
            {
                TimeSpan Interval = new TimeSpan(5,0,10); // as exemple
    
                var scServices= ServiceController.GetServices();
    
                foreach (ServiceController scTemp in scServices)
                {
                    if (scTemp.Status == ServiceControllerStatus.Running)
                    {
                        ManagementObject wmiService;
                        wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
                        wmiService.Get();
    
                        var id = Convert.ToInt32(wmiService.Properties["ProcessId"].Value);
                        Process p = Process.GetProcessById(id);
    
                        if ((DateTime.Now.Subtract(p.StartTime)) > Interval)
                        {
                            Console.WriteLine("  Service :        {0}", scTemp.ServiceName);
                            Console.WriteLine("  Display name:    {0}", scTemp.DisplayName);
                            Console.WriteLine("  StartTime:       {0}", p.StartTime);
                        }
                    }
                }
                
                Console.ReadLine();
            }
