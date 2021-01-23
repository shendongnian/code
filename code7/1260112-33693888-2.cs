        x = Convert.ToInt16(Console.ReadLine());
        Area r = new Area();
        
        if (x == 1)
        {
            Area.Square(i);
        }
        else if (x==2)
        {
            Area.Rectangle(j, i);
        }
        else if (x == 3)
        {
            Area.Triangle(j, i);
        }
        else if (x==4)
        {
            Area.Circle(i);
        }
        else
        {
            Console.WriteLine("That is an invalid choice");
        }
