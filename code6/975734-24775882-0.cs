    do{    
    Console.Write("Starting number?     ->    ");
    int number1 = int.Parse(Console.ReadLine());            
            
    Console.Write("Ending number?     ->    ");
    int number2 = int.Parse(Console.ReadLine());
            
    } 
    while (number1 >= number2)
    {
      Console.WriteLine("Starting number has to be smaller than the ending number!");
    }
