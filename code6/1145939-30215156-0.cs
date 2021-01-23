    using System;
    
    public class Test
    {
        static void Main()
        {        
            Action action1 = Main;
            Action action2 = new Action(Main);
            Action action3 = new Action(action1);
            
            Console.WriteLine(action1.Equals(action2)); // True
            Console.WriteLine(action1.Equals(action3)); // False
        }
    }
