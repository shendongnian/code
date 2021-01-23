    foreach (char ch in name)
    {
        int decNumber = ch;
        Console.WriteLine(decNumber);                
        string binary = Convert.ToString(decNumber, 2);
        Console.WriteLine(binary);             
    }
