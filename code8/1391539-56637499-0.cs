    using System;
    using System.Management;
    
    namespace GetSerialNo
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
    
                foreach (ManagementObject info in searcher.Get())
                {
                    Console.WriteLine("DeviceID: " + info["DeviceID"].ToString());
                    Console.WriteLine("Model: " + "Model: " + info["Model"].ToString());
                    Console.WriteLine("Interface: " + "Interface: " + info["InterfaceType"].ToString());
                    Console.WriteLine("Serial#: " + "Serial#: " + info["SerialNumber"].ToString());
                }
    
                Console.ReadLine();
            }
        }
    }
