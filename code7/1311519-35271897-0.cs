    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_PnPEntity");
    ManagementObjectCollection deviceCollection = searcher.Get();
    foreach (var device in deviceCollection)
    {
        try
        {
            string caption = (string)device.GetPropertyValue("Caption");
            if (caption == null)
                continue;
            Console.WriteLine(caption);
            string[] hardwareIDs = (string[])device.GetPropertyValue("HardwareID");
            if (hardwareIDs == null)
                continue;
            foreach (string hardwareID in hardwareIDs)
            {
                Console.WriteLine(hardwareID);
            }
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
