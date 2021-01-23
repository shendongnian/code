    public static Random RandomGen = new Random();
    .....
    var clickPercentage = 70;
    for (int i = 0; i < 100; i++)
    {
        double randomValueBetween0And99 = RandomGen.Next(100);
        if (randomValueBetween0And99 < clickPercentage)
        {
            //do 70% times
        }
    }
