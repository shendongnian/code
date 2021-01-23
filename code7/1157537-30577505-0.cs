            Console.WriteLine("Type in your 1st X coordinate");
            int x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Type in your 1st Y coordinate");
            int y1 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Type in your 2nd X coordinate");
            int x2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Type in your 2nd Y coordinate");
            int y2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Do you want to use the distance or midpoint formula.(Type 0 for distance and 1  for midpoint)");
            int forumlaSelection = Convert.ToInt32(Console.ReadLine());
            int dx = x1 - x2;
            int dxSquared = dx * dx;
            int dy = y1 - y2;
            int dySquared = dy * dy;
            int dxPlusDy = dx + dy;
            if (forumlaSelection == 0)
            {
                Console.Out.Write("Square Root of");
                Console.Out.Write(dxPlusDy);
            }
