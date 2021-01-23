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
            tooShortInput = true;
            break;
        }
        else
        {
            for (int j = 0; j < 10; j++)
            {
                if (numbers[j] == 0)
                {
                    numbers[j] = 2147483647;
                }
            }
            break;
        }
    }
    }
    Array.Sort(numbers);
    if (!tooShortInput) 
    {
    Console.WriteLine("Second smallest number: " + numbers[1]);
    }
