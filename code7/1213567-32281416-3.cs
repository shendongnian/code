    private static BigInteger FactorialEstimate(int number)
    {
        if (number < 2) return BigInteger.One;
        double sum = 0;
        for (int i = 2; i <= number; i++)
            sum += Math.Log(i, 2);
        return BigInteger.Pow(2, (int)Math.Round(sum));
    }
