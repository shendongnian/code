    Console.WriteLine("Enter Side 1");
    double x = double.Parse(Console.ReadLine());
    Console.WriteLine("Enter Side 2");
    double y = double.Parse(Console.ReadLine());
    double answer = Math.Sqrt(Math.Pow(x, 2) - Math.Pow(y, 2)); ;
    answer = Math.Round(answer, 4);
    Console.WriteLine("Side 3 is ~ {0}", answer);
