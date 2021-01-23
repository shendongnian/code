    bool success = int.TryParse(Console.ReadLine(), out i);
 
    if (success)
    {
        Console.WriteLine("Enter Integer!");
    }
    else
    {      
        Console.WriteLine("Output: ", i);
    }
