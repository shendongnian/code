        int x;
        while(true)
        {
            Console.Write("The first number=   ");
            
            bool success = int.TryParse(Console.ReadLine(), out x);
        
            if (success)
                break;
        }
