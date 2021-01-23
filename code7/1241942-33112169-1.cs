    static void typeTri()
    {
        if (IsEquilateral(side1, side2, side3))
        {
            Console.WriteLine("The triangle is equilateral.");
        }
        else if (IsIsosceles(side1, side2, side3))
        {
            Console.WriteLine("The triangle is isoceles.");
        }
        else
        {
            Console.WriteLine("The triangle is scalene.");
        }
    }
    private static bool IsEquilateral (int side1, int side2, int side3)
    {
        return side1 == side2 && side2 == side3;
    }
    private static bool IsIsosceles (int side1, int side2, int side3)
    {
        return (side1 == side2) 
               || (side2 == side3)
               || (side1 == side3);
    }
