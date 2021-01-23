    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                start:
                string tryagain;
    
                
               //All of your Code Goes here
                
    
                tryagain = Console.ReadLine();
                if (tryagain != "p")
                {
                goto start;    
                }
    
                else
                {
                    Environment.Exit(0);
                }
    
                
            }
        }
    }
