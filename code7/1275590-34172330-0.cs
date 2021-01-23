    class Program
    {
        static void Main(string[] args)
        {
            var thread = new Thread(() =>
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                {
                    Console.WriteLine("Hello world from Dispatcher");
                }));
                Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
