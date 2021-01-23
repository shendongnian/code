    static IEnumerable<double> masodmegold(double a, double b, double c)
    {
        double x0, x1, x2;
        double gyokalatt = b * b - 4 * a * c;
        if (a == 0)
        {
            //i want to write some text out here
            return IEnumerable.Empty; 
        }
        else
        {
            if (gyokalatt > 0)
            {
                yield return x1 = (-b + Math.Sqrt(gyokalatt)) / (2 * a);
                yield return x2 = (-b - Math.Sqrt(gyokalatt)) / (2 * a);
                // i cant return two values
            }
            else if (gyokalatt == 0)
            {
                yield return x0 = (-b / (2 * a));
            }
            else
            {
                return IEnumerable.Empty; 
                // also some text here
            }
        }
    }
    static void Main(string[] args)
    {
        foreach(string value in masodmegold(1, 4, 3))
		{
			Console.WriteLine(value);
			Console.ReadKey();
		}
    }
