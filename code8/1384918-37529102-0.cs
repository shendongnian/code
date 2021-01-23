    static void Main(string[] args)
            {
                decimal originalValue = 30.1645M;
                Console.WriteLine(originalValue.ToString());
                
                // straight forward rounding 
                decimal roundedValue = Math.Round(originalValue, 2);
                Console.WriteLine(roundedValue.ToString());
    
                Console.ReadKey();
            }
