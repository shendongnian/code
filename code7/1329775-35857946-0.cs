       using System;
    namespace ConsoleApplication1
    {
    class MainClass
    {
        public static void Main(string[] args)
        {
           Console.Beep();
            Console.Beep();
            double num1 = 0;
            double num2 = 0;
            double resultado = 0;
            //string escolhaString = null;
            //int escolha = int.Parse (escolhaString);
            int escolha;
            Console.WriteLine("Write the value of the operation: ");
            Console.WriteLine("1) +");
            Console.WriteLine("2) -");
            Console.WriteLine("3) X");
            Console.WriteLine("4) /");
            Console.WriteLine("0) Exit.");
           
            escolha = int.Parse(Console.ReadLine());
           
            if (escolha != 0)
            {
                
                Console.WriteLine("Write the first value: ");
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Write the second value: ");
                num2 = int.Parse(Console.ReadLine());
                if (escolha == 1)
                {
                    resultado = (num1 + num2);
                }
                else if (escolha == 2)
                {
                    resultado = num1 - num2;
                }
                else if (escolha == 3)
                {
                    resultado = num1 * num2;
                }
                else if (escolha == 4)
                {
                    resultado = num1 / num2;
                }
            }
            Console.WriteLine("The result is: " + resultado);
        }
    }
}
