    class Program
    {
        static void Main(string[] args)
        {
            var t = foo();
            t.Wait();
            Console.ReadKey();
        }
        class MyApplicationException : Exception { }
        static async Task foo()
        {
            try
            {
                await Task.Run(() => { throw new MyApplicationException(); });
                Console.WriteLine("Completed without exception");
            }
            catch (MyApplicationException)
            {
                Console.WriteLine("Exception caught");
            }
        }
    }
