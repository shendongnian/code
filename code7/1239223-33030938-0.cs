    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => FindPresenter(typeof(Program), "boo"))
                .ContinueWith(x => UsePresenter(x.Result));
            while (true)
            {
                Thread.Sleep(200);
                Console.WriteLine("I am the ui thread. Press a key to exit.");
                
                
                if ( Console.KeyAvailable)
                    break;
            }
               
        }
        static object FindPresenter(Type type, string action)
        {
            Thread.Sleep(1000);
            return (object)"I'm a presenter";
        }
        static void UsePresenter(object presenter)
        {
            Console.WriteLine(presenter.ToString());
            Console.WriteLine("Done using presenter.");
        }
    }
