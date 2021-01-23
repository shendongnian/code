    int rowLength = tel.GetLength(0);
    int colLength = tel.GetLength(1);
    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            Console.WriteLine(tel[i, j]+" is calling");
        }
    }
    Console.ReadLine();
