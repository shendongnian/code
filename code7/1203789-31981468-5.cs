    // Adds two numbers.  Throws a System.ArithmeticException if the result
    // is greater than MAX_VALUE or less than MIN_VALUE.
    public static decimal Add(decimal a, decimal b)
    {
        decimal result = a + b;
        if ((result > MAX_VALUE) || (result < MIN_VALUE))
        {
            throw new System.ArithmeticException(); // Or make an exception type.
        }
    }
