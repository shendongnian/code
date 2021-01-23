    public static Random RandomGen = new Random();
    .....
    int clickPercentage = 70;
    for (int i = 0; i < 100; i++)
    {
        int randomValueBetween0And99 = RandomGen.Next(100);
        if (randomValueBetween0And99 < clickPercentage)
        {
            //do 70% times
        }
    }
