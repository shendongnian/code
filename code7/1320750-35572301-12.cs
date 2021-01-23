    public static int GetRandomMultiple(int divisor, int min, int max)
    {
        if (Rnd == null)
        {
             Rnd = new Random();
        }
        if(min > max) //Assert that min is lower than max
        {
            int Temp = max;
            max = min;
            min = Temp;
        }
        int NextRandom = Rnd.Next(min, max + 1); //Add 1 to Max, because Next always returns one less than the value of Max.
        while (NextRandom % divisor != 0)
        {
            NextRandom = Rnd.Next(min, max + 1); //Add 1 to Max, because Next always returns one less than the value of Max.
        }
        return NextRandom;
    }
