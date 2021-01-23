    int display;               
    
    Console.Write("Enter three whole numbers:" );
    
    string s = Console.ReadLine();
    foreach (char num in s.ToCharArray())
    {
        display += (int)char.GetNumericValue(num);
    }
    Console.Write(display);
    Console.ReadKey();
