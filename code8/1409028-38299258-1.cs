    int numberInput;
    List<int> factors = new List<int>();
    Console.WriteLine("Enter A Number :");
    if (int.TryParse(Console.ReadLine(), out numberInput))
    {
        for (int i = 2; i <= numberInput/2; i++)
        {
            if (numberInput % i == 0)
            {
                factors.Add(i);
            }
        }
        if (factors.Count > 0)
        {
            Console.WriteLine("{0} is divisible by {1}", numberInput, String.Join(",",factors));
        }
        else 
        {
            Console.WriteLine("Number is Prime");
        }
    }
    else
    {
        Console.WriteLine("Wrong Input");
    }
    Console.ReadKey();
