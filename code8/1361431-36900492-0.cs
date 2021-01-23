    using System;
    using System.Management;
    
    namespace ConsoleApplication2
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                try
                {
                    ManagementScope Scope;
                    Scope = new ManagementScope(String.Format("\\\\{0}\\root\\CIMV2", "."), null);
                    Scope.Connect();
    
                    double totalVisibleMemory = 0;
    
                    ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
                    ManagementObjectCollection results = searcher.Get();
    
                    foreach (ManagementObject result in results)
                    {
                        totalVisibleMemory = double.Parse(result["TotalVisibleMemorySize"].ToString()) / 1024;
                        Console.WriteLine("Total Visible Memory: {0:0} mb", totalVisibleMemory);
                        Console.WriteLine("Free Physical Memory: {0:0} mb", double.Parse(result["FreePhysicalMemory"].ToString()) / 1024);
                        Console.WriteLine("Total Virtual Memory: {0:0} mb", double.Parse(result["TotalVirtualMemorySize"].ToString()) / 1024);
                        Console.WriteLine("Free Virtual Memory: {0:0} mb", double.Parse(result["FreeVirtualMemory"].ToString()) / 1024);
                    }
    
                    ObjectQuery Query = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
                    ManagementObjectSearcher Searcher = new ManagementObjectSearcher(Scope, Query);
                    UInt64 Capacity = 0;
                    foreach (ManagementObject WmiObject in Searcher.Get())
                    {
                        Capacity += (UInt64)WmiObject["Capacity"];
                    }
    
                    var totalPhysicalMemory = Capacity / (1024 * 1024); 
                    Console.WriteLine(String.Format("Total Physical Memory {0:0} mb", Capacity / (1024 * 1024)));
                    var hardwareReserved = totalPhysicalMemory - totalVisibleMemory;
                        
                        Console.WriteLine(string.Format("Hardware Reserved Memory {0:0} mb", hardwareReserved));
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Exception {0} Trace {1}", e.Message, e.StackTrace));
                }
                Console.WriteLine("Press Enter to exit");
                Console.Read();
            }
        }
    }
