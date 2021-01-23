    using System;
    using System.Threading.Tasks;
    using System.Timers;
    namespace ConsoleApplication7
    {
    class Program
    {
        static bool dataNotReceived = true;
        static readonly Timer timer = new Timer {Interval = 1000};
        static void Main(string[] args)
        {
            timer.Elapsed += (sender, eventArgs) =>
            {
                if (dataNotReceived)
                {
                    Console.WriteLine("Data not received, error thrown...");
                    throw new Exception();
                }
            };
            timer.Start();
            
            DataReceived();
            Console.ReadLine();
        }
        static async Task DataReceived()
        {
            await Task.Delay(2000);
            Console.WriteLine("Data received in time");
            dataNotReceived = false;
            timer.Stop();
        }
    }
}
