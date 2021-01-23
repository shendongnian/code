    Console.WriteLine("Введите число x");
    double x = Convert.ToDouble(Console.ReadLine());
    while (true)
    {
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
               x = (x + y);  //Store the result in x
               Console.WriteLine(x);
               break;
           case "-":
               Console.WriteLine("// Результат //");
               x = (x - y);  //Store the result in x
               Console.WriteLine(x);
               break;
           case "*":
               Console.WriteLine("// Результат //");
               x = (x * y);  //Store the result in x
               Console.WriteLine(x);
               break;
           case "/":
               if (y == 0)
               {
                   Console.WriteLine("Не дели на 0");
               }
               else
               {
                   Console.WriteLine("// Результат //");
                   x = (x / y);
                   Console.WriteLine(x);
               }
               break;
        }
    }
