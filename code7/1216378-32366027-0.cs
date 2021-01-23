    int altura; string space = ""; 
    int cont2 = 0;
    Console.Write("Dar altura: ");
    altura = int.Parse(Console.ReadLine());
    for (int i = 1; i <= altura; i++)
    {
        space = "";
        for (int j = 1; j <= i; j++)
        {
            space = space + Convert.ToString(j);
        }
        for (int k = i - 1; k >= 1 ; k--)
        {
            space = space + Convert.ToString(k);
        }
        Console.WriteLine(space);
    }
    Console.ReadKey();
