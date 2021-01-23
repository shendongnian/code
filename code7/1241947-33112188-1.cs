    static void typeTri()
        {
            if (side1 == side2 && side2 == side3)
            {
                Console.WriteLine("The triangle is equilateral.");
            }
            else if ((side1 == side2) || (side2 == side3) || (side1 == side3))
            {
                Console.WriteLine("The triangle is isoceles.");
            }
            else
            {
                Console.WriteLine("The triangle is scalene.");
            }
        }
