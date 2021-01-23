    class Calculator
    {
        private int operand1 {get; set;} //need to declare the var before using
        private int operand2 {get; set;}
        private string Message {get; set;}
        public string WriteText() //you don't need to send parameters to the function if you have already got them in the contructor
        {
            return Message;
        }
        public int GetSum()
        {
            return operand1 + operand2;
        }
        public Calculator(string Message, int operand1, int operand2)
        {
            this.Message = Message;
            this.operand1 = operand1;
            this.operand2 = operand2;
        }
    }
    class Program
        {
            static void Main(string[] args)
            {
                Calculator CalcObj = new Calculator ("Hello word!", 53, 28); //That is how you can initialize a class object   
                string s = Calculator.WriteText(); //this will return you the string you passed in controller
                Console.WriteLine(s);
    
                string n = Calculator.GetSum().ToString(); //that will give you sum of two operand
                Console.WriteLine(n);
    
                Console.ReadLine();
            }
        }
