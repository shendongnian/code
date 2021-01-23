        decimal result = a + b;
        try
        {
            if ((result > MAX_VALUE) || (result < MIN_VALUE))
            {
                throw new System.ArithmeticException(); // Or make an exception type.
            }
        }
        catch (System.ArithmeticException e)
        {
            // Do stuff.
        }
