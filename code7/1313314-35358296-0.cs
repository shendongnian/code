    public void listvms()
        {
            ManagementObjectSearcher searcher =
                      new ManagementObjectSearcher("\\root\\virtualization\\V2",
                      "SELECT ElementName FROM Msvm_ComputerSystem where Description='Microsoft Virtual Machine'");           
            if (searcher.Get().Count != 0)
            {
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    vmnamelist.Items.Add(queryObj["ElementName"]);
                }
            }            
        }
