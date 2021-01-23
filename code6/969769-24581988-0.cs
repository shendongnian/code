    double[] doubles = new double[] { 1, 2, 3}; 
    SomeMethod(ref doubles);
 
    // This will return true
    Console.WriteLine(doubles == null);
    private static void SomeMethod(ref double[] w2)
    {
        w2 = null;
    }
