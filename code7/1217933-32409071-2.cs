    const double G = 6.674E-11;
    Console.WriteLine("G is {0}", G);
		
    const double massOfEarth = 5.972E+24;
    const double massOfSun = 1.989E+30;
    const double mass = massOfSun + massOfEarth;
    Console.WriteLine("mass is {0}", mass);
		
    // 365 days in seconds
    const double period = 3.15569E+7;
    Console.WriteLine("period is {0}", period);
		
    // radius of the earth
    const double radius = 6.371E+6;
    Console.WriteLine("radius is {0}", radius);
		
    double denominator = 4 * Math.Pow(Math.PI, 2.0);
    Console.WriteLine("Denominator is {0}", denominator);
		
    double numerator = G * mass * Math.Pow(period, 2.0);
    Console.WriteLine("numerator is {0}", numerator);
		
    double fraction = numerator / denominator;
    Console.WriteLine("fraction is {0}", fraction);
        
    double root = Math.Pow(fraction, 1.0 / 3.0);
    Console.WriteLine("root is {0}", root);
        
    double result = root - radius;
    Console.WriteLine("final result is {0}", result);
