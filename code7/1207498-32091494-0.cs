    class Program
    {
        public static void Main(string[] args)
        {
            // Register at B
            BLibClass.BEvent += MyMethod;
            // Something triggers A
            ALibClass.ATrigger();
            Console.ReadKey();
        }
        public static void MyMethod()
        {
            System.Console.WriteLine("Something happeneds!");
        }
    }
    public class ALibClass
    {
        public delegate void HandleAEvent();
        public static event HandleAEvent AEvent;
        public static void ATrigger()
        {
            AEvent();
        }
    }
    public class BLibClass
    {
        public delegate void HandleBEvent();
        public static event HandleBEvent BEvent;
        private static void WhenAHappens()
        {
            BEvent();
        }
        static BLibClass()
        {
            ALibClass.AEvent += WhenAHappens;
        }
    }
