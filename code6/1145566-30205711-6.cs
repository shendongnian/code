    class Program
    {
        static void Main(string[] args)
        {
            const string SHARED_MUTEX_NAME = "something";
            int pid = Process.GetCurrentProcess().Id;
            using (Mutex mtx = new Mutex(false, SHARED_MUTEX_NAME))
            {
                while (true)
                {
                    Console.WriteLine("Press any key to let process {0} acquire the shared mutex.", pid);
                    Console.ReadKey();
                    while (!mtx.WaitOne(1000))
                    {
                        Console.WriteLine("Process {0} is waiting for the shared mutex...", pid);
                    }
                    Console.WriteLine("Process {0} has acquired the shared mutex. Press any key to release it.", pid);
                    Console.ReadKey();
                    mtx.ReleaseMutex();
                    Console.WriteLine("Process {0} released the shared mutex.", pid);
                }
            }            
        }
    }
