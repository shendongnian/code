    int i;
    int y = 1;
    for (i = 1; i <= 7; i++)
    {
        /*Console.WriteLine(i);*/ // NOT NEEDED
        for (int x = 1; x < 7; x += i)
        {
            /*Console.WriteLine("\t" + x);*/ // WRONG
            Console.WriteLine(i+"\t" + x);
        }
    }
