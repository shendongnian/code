    static void typeTri()
    {
        if (AllSidesAreEqual(side1, side2, side3))
        {
            Console.WriteLine("The triangle is equilateral.");
        }
        else if (AtLeastTwoSideAreEqual(side1, side2, side3))
        {
            Console.WriteLine("The triangle is isoceles.");
        }
        else
        {
            Console.WriteLine("The triangle is scalene.");
        }
    }
    private static bool AllSidesAreEqual (int side1, int side2, int side3)
    {
        return (side1 == side2) 
            && (side2 == side3);
    }
    private static bool AtLeastTwoSideAreEqual (int side1, int side2, int side3)
    {
        return (side1 == side2)
            || (side2 == side3)
            || (side1 == side3);
    }
