    using System.Management;
        public void TurnOnNetworkConnection()
    {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration");
                   foreach (ManagementObject queryObj in searcher.Get())
                   {
                      String Check = Convert.ToString(queryObj["DHCPLeaseObtained"]);
                      if (String.IsNullOrEmpty(Check))
                        {
                        }
                        else
                        {
                        ManagementBaseObject outParams = queryObj.InvokeMethod("RenewDHCPLease", null, null);
                        }
                   }
             }
               catch (ManagementException e)
               {
               MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
               }
    }
        public void TurnOffNetworkConnection()
    {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration"); 
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    String Check = Convert.ToString(queryObj["DHCPLeaseObtained"]);
                    if (String.IsNullOrEmpty(Check)) 
                    {
                    }
                    else
                    {
                        ManagementBaseObject outParams = queryObj.InvokeMethod("ReleaseDHCPLease", null, null);
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
    }
