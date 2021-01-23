    class Program
    {
        public static event EventHandler myEvent;
        static void Main(string[] args)
        {
            myEvent += Program_myEvent;
            myEvent.Invoke(null, new EventArgs());
        }
        private static void Program_myEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Cheese");
            Console.ReadKey();
        }
    }
