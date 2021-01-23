    int negCount = 0;
    int maxNegCount = 0;
    
    foreach (Weather w in wthrList)
    {
        if (w.temperature < 0)
        {
               negCount++;      
        }
        else
        {
               maxNegCount = Math.max(negCount, maxNegCount);
               negCount = 0;
        }
    }
