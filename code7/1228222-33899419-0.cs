    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CalculatorApplication
    {
        class Calculator
        {
            string input;
            char[] szArr;
            int length ;
            int current = -1;
            char ch;
            public Calculator(String input)
            {
                this.input = input;
                szArr = input.ToCharArray();
               length = szArr.Length;
            }
            char nextToken()
            {
                ++current;
                if(current==length) return 'p';
                return szArr[current];
            }
            public double expression()
            {
                double d = term();
                while(true){
                switch (ch)
                {
                    case '+':
                        d+= term();
                        break;
                    case  '-':
                        d -= term();
                        break;
                    default:
                        break;
    
                }
                if (ch == 'p') break;
            }
                return d;
    
            }
       
    
            public double term()
            {
                double d = primary();
                switch (ch)
                {
                    case '*':
                        d *= primary();
                        break;
                    case '/':
                         d /= primary();
                        break;
                    default:
                        break;
    
                }
                return d;
            }
            public double primary()
            {
                string str = "";
                double value = 0.0;
                while (true)
                {
    
                    ch = nextToken();
                    if (isDigit(ch))
                    {
                        str += ch;
                    }
                    else
                    {
                        break;
                    }
                }
                value = double.Parse(str);
                return value;
    
            }
    
            bool isDigit(char ch)
            {
                return ch == '0' || ch == '1' || ch == '2' || ch == '3' || ch == '4' || ch == '5' || ch == '6' || ch == '7' || ch == '8' || ch == '9';
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter expression");
                string input = Console.ReadLine();
                Console.WriteLine(new Calculator(input).expression());          
            }
        }
    }
