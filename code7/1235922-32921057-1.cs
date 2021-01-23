    for (int ii = 0; ii < MAX; ii++)
    {
        array[ii] = rand2.Next();
        if (array.Length % 1000000 == 0)
        {
            Console.Write("#");
        }
    }
