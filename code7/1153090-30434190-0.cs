            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            //total amount of free physical memory in bytes
            var Available = new ComputerInfo().AvailablePhysicalMemory;
            //total amount of physical memory in bytes
            var Total = new ComputerInfo().TotalPhysicalMemory;
            var PhysicalMemoryInUse = Total - Available;
            Object Free = new object();
            foreach (var result in results)
            {
                //Free amount
                Free = result["FreePhysicalMemory"];
            }
            var Cached = Total - PhysicalMemoryInUse - UInt64.Parse(Free.ToString());
            Console.WriteLine("Available: " + ByteToGb(Available));
            Console.WriteLine("Total: " + ByteToGb(Total));
            Console.WriteLine("PhysicalMemoryInUse: " + ByteToGb(PhysicalMemoryInUse));
            Console.WriteLine("Free: " + ByteToGb(UInt64.Parse( Free.ToString())));
            Console.WriteLine("Cached: " + ByteToGb(Cached));
