        ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_Product");
        foreach (ManagementObject mo in mos.Get())
        {
            Console.WriteLine(mo["Name"]);
            foreach (PropertyData prop in mo.Properties)
            {
                Console.WriteLine("{0}: {1}", prop.Name, prop.Value);
            }
        }
