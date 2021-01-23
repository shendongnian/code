    AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
        private void GetAllServices()
        {
            // get list of Windows services
            ServiceController[] services = ServiceController.GetServices();
            List<string> ac = new List<string>();
            // try to find service name
            foreach (ServiceController service in services)
            {
                ac.Add(service.ServiceName.ToString());
            }
            colValues.AddRange(ac.ToArray());
        }
