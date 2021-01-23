    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.ReadLine();
        }
        private async static Task Test()
        {
            await Task.Delay(100);
            throw new Exception("Exception!");
        }
    }
