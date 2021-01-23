     static void Finalcount()
        {
            Console.WriteLine("The age group tallies are");
            foreach (var item in AgeGroups )
            {
                Console.WriteLine(" under {0} = {1}", item.Key,item.Value);
            }      
          
            Console.WriteLine("The total of persons living in each district");
            foreach (int d in dist)
            {  
                Console.WriteLine("Distict {0} = {1}", d,d);                
            } 
        }
