    internal class Program
    {
        static LastInLocker locker = new LastInLocker();
        private static void Main(string[] args)
        {
            Task.Run(() => Test("A"));
            Thread.Sleep(500);
            Task.Run(() => Test("B"));
            Thread.Sleep(500);
            Task.Run(() => Test("C"));
            Console.ReadLine();
        }
        private static void Test(string name)
        {
            Console.WriteLine("{0} waits for lock", name);
            try
            {
                locker.Wait();
                Console.WriteLine("{0} acquires lock", name);
                Thread.Sleep(4000);
                locker.Release();
                Console.WriteLine("{0} releases lock", name);
            }
            catch (Exception)
            {
                Console.WriteLine("{0} fails to acquire lock", name);
            }
        }
    }
