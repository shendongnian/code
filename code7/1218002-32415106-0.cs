    int a = 5, b = 10, c = 20; 
    int result;
    if (a < b)
    { 
        if (a < c)
        {
            result = c;
        }
        else
        {
            result = a;
        }
    }
    else
    {
        result = b;
    }
    Console.WriteLine(result);
