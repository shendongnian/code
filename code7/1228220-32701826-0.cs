            while(true){
            Console.WriteLine("Введите число x");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите число y");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("// Выберите операцию //");
            Console.WriteLine("+ - сложение");
            Console.WriteLine("- - вычитание");
            Console.WriteLine("* - умножение");
            Console.WriteLine("/ - деление");
            string z = Console.ReadLine();
                switch (z)
                {
                    case "+":
                        Console.WriteLine("// Результат //");
                        Console.WriteLine(x + y);
                        break;
                    case "-":
                        Console.WriteLine("// Результат //");
                        Console.WriteLine(x - y);
                        break;
                    case "*":
                        Console.WriteLine("// Результат //");
                        Console.WriteLine(x * y);
                        break;
                    case "/":
                        if (y == 0)
                        {
                            Console.WriteLine("Не дели на 0");
                        }
                        else
                        {
                            Console.WriteLine("// Результат //");
                            Console.WriteLine(x / y);
                        }
                        break;
                }
                Console.WriteLine("Do you want to exit ?! Y:N?");
                char Terminat= Console.ReadKey().KeyChar;
               if(Terminat=='Y'||Terminat=='y'){
                 break;
                  }
    }
