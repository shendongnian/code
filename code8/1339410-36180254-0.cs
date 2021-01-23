     public static void Main()
     {
         try
         {
             ManagementObjectSearcher searcher =
                 new ManagementObjectSearcher("root\\CIMV2",
                 "SELECT * FROM Win32_SoundDevice");
    
             foreach (ManagementObject queryObj in searcher.Get())
             {
                 Console.WriteLine("-----------------------------------");
                 Console.WriteLine("List of sound cards installed");
                 Console.WriteLine("-----------------------------------");
                 Console.WriteLine("ProductName: {0}", queryObj["ProductName"]);
                 Console.WriteLine("Availability: {0}", queryObj["Availability"]);
                 Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                 Console.WriteLine("ConfigManagerErrorCode: {0}", queryObj["ConfigManagerErrorCode"]);
                 Console.WriteLine("ConfigManagerUserConfig: {0}", queryObj["ConfigManagerUserConfig"]);
                 Console.WriteLine("CreationClassName: {0}", queryObj["CreationClassName"]);
                 Console.WriteLine("Description: {0}", queryObj["Description"]);
                 Console.WriteLine("DeviceID: {0}", queryObj["DeviceID"]);
                 Console.WriteLine("DMABufferSize: {0}", queryObj["DMABufferSize"]);
                 Console.WriteLine("ErrorCleared: {0}", queryObj["ErrorCleared"]);
                 Console.WriteLine("ErrorDescription: {0}", queryObj["ErrorDescription"]);
                 Console.WriteLine("InstallDate: {0}", queryObj["InstallDate"]);
                 Console.WriteLine("LastErrorCode: {0}", queryObj["LastErrorCode"]);
                 Console.WriteLine("Manufacturer: {0}", queryObj["Manufacturer"]);
                 Console.WriteLine("MPU401Address: {0}", queryObj["MPU401Address"]);
                 Console.WriteLine("Name: {0}", queryObj["Name"]);
                 Console.WriteLine("PNPDeviceID: {0}", queryObj["PNPDeviceID"]);
                 Console.WriteLine("PowerManagementSupported: {0}", queryObj["PowerManagementSupported"]);
                 Console.WriteLine("Status: {0}", queryObj["Status"]);
                 Console.WriteLine("StatusInfo: {0}", queryObj["StatusInfo"]);
                 Console.WriteLine("SystemCreationClassName: {0}", queryObj["SystemCreationClassName"]);
                 Console.WriteLine("SystemName: {0}", queryObj["SystemName"]);
             }
         }
         catch (ManagementException e)
         {
            Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
         }
     }
