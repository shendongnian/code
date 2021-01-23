    Console.WriteLine("enter number of conversations");
    if(int.TryParse(Console.ReadLine(), out n)
    {
        if (n <= 100)
        {
            sum = sum + n * 5;
        }
        else
        {
            sum += (100 * 5) + (n - 100) * 7;
        }
        Console.WriteLine(sum);
    }
    else
    {
       Console.WriteLine("Invalid input , Enter only number");
    }
