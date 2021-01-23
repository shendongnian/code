    static void Main(string[] args) {
        Console.WriteLine("");
        string Calc = Console.ReadLine();
        char[] operands = { '+', '-', '/', '*' };
        int index = Calc.IndexOfAny(operands);
        if (index != -1)
        {
            Console.WriteLine(Calc.Substring(index));
            string thing = Calc.Substring(index + 1);
            char x = Calc[index];
    
            Calc = Calc.Substring(0, index);
            Calc = Calc.Replace(" ", "");
            Console.WriteLine("{0} first value",Calc);
            Console.WriteLine("{0} operand value", x);
            Console.WriteLine("{0} second value", thing);
            switch(x)
            {
                case '+':
                    Console.WriteLine(Convert.ToInt32(Calc) + Convert.ToInt32(thing));
                    break;
                case '-':
                    Console.WriteLine(Convert.ToInt32(Calc) - Convert.ToInt32(thing));
                    break;
                case '/':
                    Console.WriteLine(Convert.ToInt32(Calc) / Convert.ToInt32(thing));
                    break;
                case '*':
                    Console.WriteLine(Convert.ToInt32(Calc) * Convert.ToInt32(thing));
                    break;
            }
        }
        Console.ReadLine(); }
