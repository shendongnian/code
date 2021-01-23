    int total = 0;
    for (i = 0; i <= 10; i++)
    {
       if (i == 0) // First time asking for a number
           Console.WriteLine("Please enter a number");
       else
           Console.WriteLine("Please enter another number");
       userNumber = int.Parse(Console.ReadLine());
       total = userNumber + total;
       Console.WriteLine("The running total is: " + total);
    }
