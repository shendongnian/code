    for (int i = 0; i < 2; i++)
    {
        Console.WriteLine("number:");    
        string input = Console.ReadLine();
    
        int num;
        if(int.TryParse(input, out num))
            ft[i] = num;
        else 
            break;
    }
