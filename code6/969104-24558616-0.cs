        Console.WriteLine("Would you like to add this Machine to the repairs list?");
        var addToRepairs = Console.ReadLine().ToLower();
        while(AddMachineToRepairsList(addToRepairs)==false) 
    {
     Console.WriteLine("Please enter machine information again");
        this.Run();
    }
         
