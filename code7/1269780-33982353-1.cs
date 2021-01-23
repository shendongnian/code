    public void printPoly1(int[] poly, int n)
    {
        for (int i = n-1; i  >= 0; i--)
        {
            Console.Write(poly[i]);
            if (i != 0)
            {
                Console.Write("x^" + i + " + ");
            }
        }
        Console.WriteLine("\n");
    }
