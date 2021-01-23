    int tmp;
    bool success = int.TryParse(Console.ReadLine(), out tmp); 
    if (success)
    { 
        ft[i] = tmp;
    }
    else // error handling here
