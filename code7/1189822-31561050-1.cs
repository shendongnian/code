    namespace A
    {
       class Program
        {
           static void Main(string[] args)
            {
               var evh = new EventWaitHandle(false, EventResetMode.AutoReset,"fromA");
               Console.WriteLine("Anykey to send signal");
               Console.ReadKey();
                evh.Set();
            }
        }
    }
    
    namespace B
    {
       class Program
        {
           static void Main(string[] args)
            {
               Console.WriteLine("Waiting for a signal");
               var evh = EventWaitHandle.OpenExisting("fromA");
                evh.WaitOne();
               Console.WriteLine("Signal!");
               Console.ReadKey();
            }
        }
    }
