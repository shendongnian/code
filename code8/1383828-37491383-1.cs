     class Item
     {
         public Item( string line )
         {
             var split = line.Split(',');
             A = split[0];
             B = split[1];
             C = split[2];
             D = split[3];
             E = int.Parse( split[4] );
         }
         // [...]
     }
