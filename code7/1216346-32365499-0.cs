    int altura; 
    Console.WriteLine("Dar altura: ");
    altura = int.Parse(Console.ReadLine());
    for (int i = 1; i <= altura; i++)
    {
      string space = "";
      for (int j = 1; j <= i; j++)
      {
        space = space + Convert.ToString(j);
      }
      Console.WriteLine(space);
    }
    Console.ReadLine();
