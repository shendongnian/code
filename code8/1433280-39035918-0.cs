    namespace A
    {
        public class Aapi
        {
            public static void DoTheBusiness()
            {
                Console.WriteLine("Aapi::DoTheBusiness: DONE!");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Aapi.DoTheBusiness();
            }
        }
    }
