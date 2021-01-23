            double input1 = 45;
            double input2 = 42;
            double input3 = 1;
            double a = (input1 - input2 * Math.Pow(input3, 2.0))
                / (1 - Math.Pow(input3, 2.0));
            Console.WriteLine((input1 - input2 * Math.Pow(input3, 2.0)));
            Console.WriteLine((1 - Math.Pow(input3, 2.0)));
            Console.WriteLine(a);
