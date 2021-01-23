    class Program
        {
            private const string MMF_NAME = "Global\\SharedMemoryExample";
            const int BUFFER_SIZE = sizeof(byte) * 1024 * 1024;
    
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Shared Memory example. .NET reader");
                    Console.WriteLine("BUFFER_SIZE: {0} bytes", BUFFER_SIZE);
                    Console.WriteLine("MMF name: {0}", MMF_NAME);
    
                    Console.WriteLine("Press 'Enter' to open Shared memory");
                    Console.ReadLine();
    
                    using (var mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.OpenExisting(MMF_NAME))
                    {
                        Console.WriteLine("{0} was opened.", MMF_NAME);
    
                        using (var accessor = mmf.CreateViewAccessor())
                        {
                            Console.WriteLine("ViewAccessor was created.");
    
                            byte[] buffer = new byte[BUFFER_SIZE];
    
                            Console.WriteLine("Press 'Enter' to read from Shared memory");
                            Console.ReadLine();
    
                            int cntRead = accessor.ReadArray(0, buffer, 0, BUFFER_SIZE);
                            Console.WriteLine("Read {0} bytes", cntRead);
    
                            if (IsBufferOk(buffer, cntRead))
                                Console.WriteLine("Buffer is ok");
                            else
                                Console.WriteLine("Buffer is bad!");
                        }
                    }
                }
                catch(Exception  ex)
                {
                    Console.WriteLine("Got exception: {0}", ex);
                    Console.ReadLine();
                }
            }
            private static bool IsBufferOk(byte[] buffer, int length)
            {
                for(int i = 0; i < length; i++)
                {
                    if (buffer[i] != 0XFA)
                        return false;
                }
                return true;
            }
        }
