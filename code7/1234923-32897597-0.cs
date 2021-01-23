    #define FOREST_CAN_RUN
    //undef FOREST_CAN_RUN --> disable that feature
    using System;
    namespace Test
    {
        public class Forest
        {
            public void Run()
            {
    #if FOREST_CAN_RUN
                Console.Write("Run Forest, Run !");
    #else
                Console.Write("Sorry, Jenny");
    #endif
            }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                Forest f= new Forest ();
                f.Run();
            }
        }
    }
