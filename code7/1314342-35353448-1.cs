    static void Main(string[] args)
    {
        //Create random numbers
        var rnd = new Random();
        var randomNumber1 = rnd.Next(1, 100); //get a random int between 1 and 99
        var randomNumber2 = rnd.Next(1, 100); //and again
        
        //Create instance of Calculator Class
        var calc = new Calculator(randomNumber1, randomNumber2);
        //Intro
        string s = calc.WriteText("Hello World!");
        Console.WriteLine(s);
        
        //Do your addition method
        var n = calc.WriteNumber(53 + 28);
        Console.WriteLine(n);
        //Do new addition method
        var result = calc.Add(); //Returns _operand1 + _operand2
        Console.WriteLine(result);
        //exit application
        Console.ReadLine();
    }
    class Calculator
    {
        // Set fields for your constructor to use.
        // Another valid option is using properties, google this as its beyond the scope of a basic tutorial
        private int _operand1, _operand2;
        public string WriteText(string parametar1)
        {
            return parametar1;
        }
        public int WriteNumber(int parametar2)
        {
            return parametar2;
        }
        public int Add()
        {
            return _operand1 + _operand2;
        }
        public Calculator(int operand1, int operand2)
        {
            //You don't need the this keyword
            _operand1 = operand1;
            _operand2 = operand2;
        }
    }
