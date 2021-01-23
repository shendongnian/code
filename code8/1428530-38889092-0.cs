                Console.WriteLine("How many Numbers Do you want? ");
            int counter = int.Parse(Console.ReadLine());
            double[] numbers = new double[counter];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write((i + 1) + " : ");
                numbers[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("_______________________________________________");
            Array.Sort(numbers);
            Array.Reverse(numbers);
            foreach (double item in numbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("_______________________________________________");
            Console.WriteLine("The Greatest Number is " + numbers[0]);
            Console.ReadKey();
