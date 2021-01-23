    private static string ToFraction64(double value) {
      int denominator = 64;
      int integer = (int) value;
      int numerator = 
        (int) (Math.Round((Math.Abs(value) - Math.Abs(integer)) * denominator) + 0.5);
      
      while ((numerator % 2 == 0) && (denominator % 2 == 0)) {
        numerator /= 2;
        denominator /= 2;
      }
      if (denominator > 1)
        return string.Format("{0} {1}/{2}", integer, numerator, denominator);
      else 
        return integer.ToString();   
    }
...
    
    const double cmInInch = 2.54;
    // 1 17/64
    Console.Write(ToFraction64(3.21 / cmInInch));
    // -1 17/64
    Console.Write(ToFraction64(-1.26378));
    // 3 1/4
    Console.Write(ToFraction64(3.25001));
    // 3 1/4
    Console.Write(ToFraction64(3.24997));
