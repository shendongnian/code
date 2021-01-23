    class FinalizableObject
    {
        ~FinalizableObject()
        {
            Thread.Sleep(50000);
            Console.WriteLine("Finalized");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            new FinalizableObject();
        }
    }
