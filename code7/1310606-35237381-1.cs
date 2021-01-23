    class Program
    {
        static void Main(string[] args)
        {
          // Change 1
            bool bktop = true;
            string option;
            while (bktop)
            {
                bktop = true;
                Console.WriteLine("Please enter the values");
                int val = int.Parse(Console.ReadLine());
                int val1 = int.Parse(Console.ReadLine());
                int res = val + val1;
                int red = val / val1;
                Console.WriteLine("Please enter the operator");
                string oper = Console.ReadLine();
                if (oper == "+")
                {
                    Console.WriteLine("sum is:" + res);
                }
                else if (oper == "/")
                {
                    Console.WriteLine("division is:" + red);
                }
                else
                {
                    Console.WriteLine("do you want to continue? enter Y/N");
                    option = Console.ReadLine();
                    // Change 2
                    if (option.ToUpper() != "Y")
                    {
                        bktop = false;
                    }
                }
            }
        }
    }
