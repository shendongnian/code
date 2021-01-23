    try
    {
        Console.WriteLine("Please Enter the Item Name");
        item1.itemname = Console.ReadLine();
    
        if([Put here a condition to validate item1.itemname format]) 
             throw new SomeException();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.Write("Please enter Name in the Correct Format");
        if (e.Message != null)
            z = 1;
    }
