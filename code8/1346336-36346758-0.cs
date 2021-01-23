    Console.WriteLine("Prime Number:");
    int Limit;
    if (!int.TryParse(Console.ReadLine(), out Limit))
       {
          Console.WriteLine("Invalid input");
       }
    Console.WriteLine("List of prime numbers are :");
    for (int i = 2; i < Limit; i++)
       {
          if (checkForPrime(i))
              Console.WriteLine(i);
       }
    Console.ReadKey();
