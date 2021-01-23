        private int GetActiveMonitors()
        {
            int Counter = 0;
            System.Management.ManagementObjectSearcher monitorObjectSearch = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_DesktopMonitor");
            foreach (ManagementObject Monitor in monitorObjectSearch.Get())
            {
                UInt16 Status = 0;
                try
                {
                    Status = (UInt16)Monitor["Availability"];
                }
                catch (Exception ex)
                {
                    //Error handling if you want to
                    continue;
                }
                if (Status == 3)
                    Counter++;
            }
            return Counter;
        }
