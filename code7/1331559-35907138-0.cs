     var answer = 0;
            var num = 0;
            var num2 = 0;
            while(answer!=1)
            {
                Console.Write("Enter number: ");
                num = Int32.Parse(Console.ReadLine());
                Console.Write("Enter number: ");
                num2 = Int32.Parse(Console.ReadLine());
                var sum = num + num2;
                Console.WriteLine("Sum is: " + sum);
                Console.Write("Press 1 to exit or 2 to continue: ");
                answer = Int32.Parse(Console.ReadLine());
            };
