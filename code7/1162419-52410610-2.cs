    decimal valOne = decimal.Round(valueOne, 6);
    decimal valTwo = decimal.Round(valueTwo, 6);
    double dblOne = Convert.ToDouble(valOne);
    double dblTwo = Convert.ToDouble(valTwo);
    double epsilon = 0.0000001;
    if (nearlyEqual(dblOne, dblTwo, epsilon))
    {
        Console.WriteLine("Values are equal");
    }
    else
    {
        Console.WriteLine("Values are different");
    }
