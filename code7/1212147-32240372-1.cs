    int input;
    if (!int.TryParse(Console.ReadLine(), out input);
    {
        Console.WriteLine("Invalid number");
    }
    else 
    {
        resul[1] = input;
    }    
    if (resul[1] > 0) //use resul[1]<1 for negative switch case
    {
         switch (resul[1])
         {
             case 1:    
                Console.WriteLine("Username taken.");    
                break;    
             case 2:    
                Console.WriteLine("Email address taken.");    
                break;    
         }    
         Console.WriteLine("User added.");
         Assert.IsTrue(true);
    }
