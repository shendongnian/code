    class Program
    {
        static IList<byte[]> small = new List<byte[]>();
        static IList<byte[]> big = new List<byte[]>(); 
        static void Main()
        {
            int totalMB = 0;
            try
            {
                Console.WriteLine("Allocating memory...");
                while (true)
                {
                    big.Add(new byte[10*1024*1024]);
                    small.Add(new byte[85000-3*IntPtr.Size]);
                    totalMB += 10;
                    Console.WriteLine("{0} MB allocated", totalMB);
                }
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Memory is full now. Attach and debug if you like. Press Enter when done.");
                Console.WriteLine("For WinDbg, try `!address -summary` and  `!dumpheap -stat`.");
                Console.ReadLine();
                
                big.Clear();
                GC.Collect();
                Console.WriteLine("Lots of memory has been freed. Check again with the same commands.");
                Console.ReadLine();
                try
                {
                    big.Add(new byte[20*1024*1024]);
                }
                catch(OutOfMemoryException)
                {
                    Console.WriteLine("It was not possible to allocate 20 MB although {0} MB are free.", totalMB);
                    Console.ReadLine();
                }
            }
        }
    }
