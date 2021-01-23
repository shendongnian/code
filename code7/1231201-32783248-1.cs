    Console.Write("Input: ");
    int i;
    bool success = int.TryParse(Console.ReadLine(), out i); //Getting the input and checking it
 
    if (!success)
    {
        Console.WriteLine("Enter Integer!");
    }
    else
    {      
        Console.WriteLine("Output: ", i);
    }
