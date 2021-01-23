    int[] array = {1, 2, 3, 5, 8, 10, 15, 23};
    var subsets = new List<IEnumerable<int>>();
    int counter = 0;
    
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 2; j < array.Length - i; j++)
        {
            if (array.Contains(array.Skip(i).Take(j).ToList().Sum()))
            {
                counter++;
            }
        }
    }
    
    Console.WriteLine("Number of subsets:" + counter);
