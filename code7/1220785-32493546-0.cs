    string x;   
    double t, s = 1;    
    int digitCount = 0;
    Console.WriteLine("Enter some numbers: ");
    Console.WriteLine("To finish, press Enter");
    while ((x = Console.ReadLine()) != "")
    {
        if (!Double.TryParse(x, out t))
            continue;
        for (var c in x)
            if (Char.IsDigit(c))
                digitCount++;
        s *= t;
    }   
    Console.WriteLine("The result is: {0}", s);  
    Console.WriteLine("The count of digits is: {0}", digitCount);    
    Console.ReadLine();
