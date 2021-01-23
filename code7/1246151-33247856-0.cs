     Random randomnumber = new Random();
    
            int[] Player = new int[5];
            Player[0] = randomnumber.Next(1, 6); 
            Player[1] = randomnumber.Next(1, 6); 
            Player[2] = randomnumber.Next(1, 6); 
            Player[3] = randomnumber.Next(1, 6); 
            Player[4] = randomnumber.Next(1, 6);
            Console.WriteLine("You rolled a " + Player[0] + " " + Player[1] + " " + Player[2] + " " + Player[3] + " " + Player[4]);
            var selected = from x in Player.AsEnumerable()
                           group x by x into g
                           select new { Digit = g.Key, DigitCount = g.Count()};
         foreach(var sel in selected)
         {
           Console.WriteLine("You have rolled " + sel.Digit + " no of times " + sel.DigitCount);
         }
