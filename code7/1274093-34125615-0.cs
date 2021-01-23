    int[] cpt = new int[3];
    for (l = 0; l <= 5; l++)
        for (c = 0; c <= 2; c++)
            if (notes[l, c] % 2 != 0)
                cpt[c]++;
    
    Console.WriteLine("---------------------");
    foreach (var icpt in cpt)
    {
        Console.Write("{0,3}   ", icpt);
    }
