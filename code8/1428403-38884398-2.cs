    static void Main(string[] args)
    {
        // No need to initialise variable passed as "out" parameter
        List<Coordinate> objects;
        testfunction(test, out objects);
    }
    static void testfunction(int test, out List<Coordinate> objects)
    {
        // Removing this line would be a syntax error
        objects = new List<Coordinate>();
    }
