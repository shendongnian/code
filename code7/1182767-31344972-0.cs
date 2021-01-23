    Console.WriteLine("My Job is to take the factorial of the number you give");
    Console.WriteLine("What is the number?");
    int c = Convert.ToInt32(Console.ReadLine());
    int total = 1;
    for (int i = 2; i < c; i++)
    {
        total *= i;
    }
    Console.WriteLine(total.ToString());
    Console.ReadLine();
