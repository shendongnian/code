        class Program
        {
            static void Main(string[] args)
            {
                Example W = new Example();
                W.Num = 10;
            
                Example W1 = new Example();
                
                Console.WriteLine("{0}", W.Num);  //10
                Console.WriteLine("{0}", W1.Num); //0
            }
        }
