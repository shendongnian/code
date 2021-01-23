    if (int.Parse(a) >= MaxLength && int.Parse(a) <= MinLength)
    {
        string b = a.Substring(0, 1);
        string b1 = a.Substring(1, 1);
        string b2 = a.Substring(2, 1);
        string b3 = a.Substring(3, 1);
        Console.WriteLine(b + " " + b1 + " " + b2 + " " + b3);
    }
    else
    {
        Console.WriteLine("Error");
    }
