    using System;
    using System.Management;
    
    namespace MOSearcher
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                ManagementObjectCollection mo = new ManagementObjectSearcher("Select * from Win32_PingStatus where Address = 'localhost'").Get();
                foreach (ManagementObject m in mo)
                {
                    Console.WriteLine(m["Address"]);
                    Console.WriteLine(m["StatusCode"]);
                }
                Console.ReadKey();
            }
        }
    }
