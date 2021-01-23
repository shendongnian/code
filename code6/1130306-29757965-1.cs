    static void Main(string[] args)
    {
        int stockbankInput = 0;
        bool firstTry = true;
        while(stockbankInput < 1 | stockbankInput > 3)
        {
           if(!firstTry)
               Console.WriteLine("Error: Please enter either 1, 2 or 3");
 
           firstTry = false;
           Int32.TryParse(Console.ReadLine(), out stockbankInput);                
        }
    }
