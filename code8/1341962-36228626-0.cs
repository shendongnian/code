    string input = "0000000002001";
    decimal  value;
    if (decimal.TryParse(input, out value))
    {
        value = value / 100;
        string result = value.ToString("0.00");
        Console.WriteLine(result);
    
    }
    else
       Console.WriteLine("Input is not a valid number");
