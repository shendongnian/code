    const int numberOfCredits = 15;
    int[] credits = new int[numberOfCredits];
...
    else if (a == 2)
    {
        int total = 0;
        int count = 0;
        while (count < numberOfCredits)
        {
            Console.WriteLine("Enter credit #" + (count + 1).ToString() + ":");
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                credits[count] = input;
                total += input;
                count += 1;
            }
        }
        Console.WriteLine(total);
    }
