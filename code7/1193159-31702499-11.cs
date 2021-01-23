    using System;
    
    namespace WaitOnTasksToComplete
    {
        class Program
        {
            static void Main(string[] args)
            {
                Car c = new Car();
                c.OnChange += C_OnChange;
    
                c.Speed = 5;
                c.Speed = 55;
                c.Speed = 65;
                c.Speed = 75;
    
            }
    
            private static void C_OnChange()
            {
                Console.WriteLine("Event fired: Car goes higher than 60 MPH.");
            }
        }
    }
