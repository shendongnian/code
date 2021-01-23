    Console.WriteLine("Enter the Limit:");
    int Limit;
    if (!int.TryParse(Console.ReadLine(), out Limit))
       {
          Console.WriteLine("Invalid input");
       }
    Console.WriteLine("List of prime numbers between 0 and {0} are :",Limit);
    for (int i = 2; i < Limit; i++)
       {
          if (checkForPrime(i))
              Console.WriteLine(i);
       }
    Console.ReadKey();
