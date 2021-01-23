    List<List<string>> list = new List<List<string>>();
    try
    {
        for (UInt32 I = 0; I < 134217727; I++)
        {
            List<string> SubList = new List<string>();
    
            list.Add(SubList);
    
            for (UInt32 x = 0; x < 134217727; x++)
            {
                SubList.Add("random string");
            }
        }
    }
    catch (Exception Ex)
    {
        Console.WriteLine(Ex.Message);
        Microsoft.VisualBasic.Devices.ComputerInfo CI = new ComputerInfo();
        Console.WriteLine(CI.AvailablePhysicalMemory);
    }
