    internal class Program
    {
        public class ClosureHelper
        {
             public Random rnd1;
             public Random rnd2;
            
             void MethodOne()
             {
                  Program.G(rnd1);
             }
        
             void MethodTwo()
             {
                  Program.G(rnd2);
             }
        }
    }
