     public List<string> GetWindowsServicesList()
        {
            var result = new List<string>();
            foreach (ServiceController service in ServiceController.GetServices())
            {
                string serviceName = service.ServiceName;
                result.Add(serviceName);
            }
            return result;
        }
        public ServicesModel GetServiceProperties(string serviceName)
        {
            ServicesModel service = null;
            string path = $"Win32_Service.Name=\"{serviceName}\"";
            using (ManagementObject mngObj = new ManagementObject(path))
            {
                service = new ServicesModel
                {
                    Name = mngObj.GetPropertyValue("Name") as string,
                    Path = mngObj.GetPropertyValue("PathName") as string,
                    Description = mngObj.GetPropertyValue("Description") as string,
                    Pid = Convert.ToInt32(mngObj.GetPropertyValue("ProcessId")),
                    Status = mngObj.GetPropertyValue("State") as string,
                    StartMode = mngObj.GetPropertyValue("StartMode") as string,
                    LogOnAs = mngObj.GetPropertyValue("StartName") as string
                };
            }
            return service;
        }
        public List<ServicesModel> WindowsServicesCollection()
        {
            var result = new List<ServicesModel>();
            try
            {
                var windowsServicesNames = GetWindowsServicesList();
                for (int i = 0; i < windowsServicesNames.Count(); i++)
                {
                    result.Add(GetServiceProperties(windowsServicesNames[i]));
                }
            }
            catch (System.Management.ManagementException ex)
            {
            }
            catch (System.TimeoutException ex)
            {
            }
            return result;
        }
