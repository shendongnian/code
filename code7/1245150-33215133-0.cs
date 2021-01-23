    Console.WriteLine("Input a year from 0 to 10000 to determine the next year with distinct numbers");
    string a = Console.ReadLine();
    int MaxLength = 10000;
    int MinLength = 0;
    int val = 0;
    bool isValidEntry = int.TryParse(a, out val);
    if (isValidEntry && val <= MaxLength && val >= MinLength)
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
    Console.ReadKey();
    
