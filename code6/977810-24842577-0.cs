    ManagementClass managClass = new ManagementClass("win32_processor");
    ManagementObjectCollection managCollec = managClass.GetInstances();
    foreach (ManagementObject managObj in managCollec)
    {
       foreach (var prop in managObj.Properties)
       {
           Console.WriteLine("Property Name: {0} Value: {1}",prop.Name,prop.Value);
       }               
    }
    Console.ReadKey();
