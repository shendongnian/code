        int input = int.Parse(Console.ReadLine());
        if (input != 0)
        {
            numbers[i] = input;
        }
        else
        {
            if (i == 2)
            {
                Console.WriteLine("You only entered two numbers!");
            }
            else
            {
                break;
            }
        }
    }
    Array.Sort(numbers);
    Console.WriteLine("Second smallest number: " + numbers[1]);
