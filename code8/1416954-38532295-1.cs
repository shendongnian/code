    bool powered = true;
    int cost = 50;
    int memorybar = 96;
    switch (powered)
    {
        case true:
            if (cost + memorybar > 100)
            {
                Console.WriteLine("entered A");
                powered = false;
                break;
            }
            else
            {
                Console.WriteLine("entered B");
                memorybar = memorybar + cost;
                break;
            }
        case false:
            Console.WriteLine("entered C");
            memorybar = memorybar + cost;
            break;
    }
    Console.ReadLine();
