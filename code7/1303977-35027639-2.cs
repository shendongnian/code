    static void GenReport()
    {
        uint s, n;
        string shapeName;
    
    
        Console.WriteLine();
        Console.WriteLine("       Polygon                                          Sum of ");
        Console.WriteLine(" s      Name        n=1 n=2 n=3 n=4 n=5 n=6 n=7 n=8 n=9 Recip  ");
        Console.WriteLine("--- --------------- --- --- --- --- --- --- --- --- --- ------ ");
        for (s = 3; s <= 24; s++)
        {
            shapeName = Console.ReadLine().Trim();
            Console.WriteLine("{0,3} {1}", s, shapeName);
            double sum = 0; // declare a variable outside the loop for the sum
            for (n = 1; n <= 9; n++)
            {
                double currentNumber = Math.Round(1.0/p(s, n), 4);
                Console.Write("{0} ", currentNumber);
                sum += currentNumber;
            }
            Console.Write("{0}", sum);
        }
    }
    
    static uint p(uint s, uint n)
    {
        return (n * n * (s - 2) - n * (s - 4)) / 2;
    }
     
