    int[10] Num;
    while(true)
    {
        Console.WriteLine("Enter an integer or ‘q’ to quit: ");
        string in = Console.ReadLine();
        if(in=="q")
        {
            break;
        }
        else if(int.Parse(in)>-1&&int.Parse(in)<11)
        {
            Num[int.parse(in)]++;
        }
        for(int i=0; i<10; i++)
        {
            if(Num[i]>0)
                Console.WriteLine(i.ToString() + " " Num[i].ToString());
        }
    }
