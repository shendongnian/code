    int a = int.Parse(Console.ReadLine());
    int b = int.Parse(Console.ReadLine());
    int i = Math.Min(a ,b);
    while (i > 1)
    {
      if (a % i == 0 && b % i == 0)
      {
          Console.WriteLine("GCD:{0}", i);
          break;//greatest will be the first
      }
      i--;
     }
