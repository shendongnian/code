    class Program
    {
        static void Main(
            string[] args
            )
        {
            var ser = new ServiceReference1.Service1Client();
            ser.Endpoint
                .Behaviors
                .Add(new MessageInspectorBehavior());
            var f = ser.GetData(10);
            Console.WriteLine(f);
            Console.ReadKey();
        }
    }
