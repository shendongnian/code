    resul[1] = Convert.ToInt32(Console.ReadLine());
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
