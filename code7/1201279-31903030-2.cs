    int x;
    
    back:
    Console.Write("The first number=   ");
    
    bool success = int.TryParse(Console.ReadLine(), out x);
    
    if (!success)
        goto back;
