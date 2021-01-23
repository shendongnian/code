    bool isValid = true;
    foreach (char c in str)
    {
        if (c < '0' || c > '7')
        {
            isValid = false;
            break;
        }
    }
    
    if (isValid)
    {
        Console.WriteLine("good");
    }
    else
    {
        Console.WriteLine("bad");
    }
