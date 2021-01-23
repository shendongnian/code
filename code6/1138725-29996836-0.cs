    private static double DegreesToRadians(double angle)
    {
    
        return angle * (Math.PI / 180.0 );
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine((75 * Math.Cos(DegreeToRadians(90))).ToString());
    }
