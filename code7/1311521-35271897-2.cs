    ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_PnPEntity");
    ManagementObjectCollection deviceCollection = searcher.Get();
    foreach (var entity in deviceCollection)
    {
        Win32_PnPEntity device = new Win32_PnPEntity(entity);
        Console.WriteLine($"Caption: {device.Caption}");
        Console.WriteLine($"Description: {device.Description}");
        Console.WriteLine($"Number of hardware IDs: {device.HardwareID.Length}");
        foreach (string hardwareID in device.HardwareID)
        {
            Console.WriteLine(hardwareID);
        }
        Console.WriteLine();
    }
