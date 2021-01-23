    namespace Exercise_4
    {
        class Program
        {
            static void Main(string[] args)
            {    
                int numberToCollect = 10;    
                int[] answers = new int[numberToCollect];
                int numberCollected = 0;
                
                while(numberCollected<numberToCollect) 
                {
                    int parsedInt = 0;
                	if (int.TryParse(intConsole.ReadLine(),out parsedInt))
                    {
                       answers[numberCollected++] = parsedInt;
                    }
                    else 
                    {
                         Console.WriteLine("Invalid number, try again!");
                    }
                }
                
                for(var cnt in answers) 
                {
                    Console.WriteLine(new String('*',cnt));
                }
            }
        }
    }
