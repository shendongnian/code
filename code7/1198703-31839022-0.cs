    class ConsoleWriterActor : ReceiveActor
    {
        public ConsoleWriterActor()
        {
            ReceiveAny(o => Console.WriteLine("Received object: " + o));
        }
    }
