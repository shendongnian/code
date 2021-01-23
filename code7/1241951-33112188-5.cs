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
            else if ((side1 >= side2 + side3) || (side2 >= side1 + side3) || (side3 >= side1 + side2) || (side1 <= 0) || (side2 <= 0) || (side3 <= 0))
            {
                Console.WriteLine("Not a Triangle");
            }
            else
            {
                Console.WriteLine("The triangle is scalene.");
            }
        }
