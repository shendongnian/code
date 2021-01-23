    while(name.Length == 0) 
    {
        Console.Write("Name: ");
        name = Console.ReadLine();
        
        if(name.Length == 0)
        {
            Console.WriteLine("Name cannot be empty");
        }
    }
