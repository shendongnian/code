    int[] elem = new int[] { 1, 2, 3 };
    double maxElem = Math.Pow(2, elem.Length);
    for (int i = 0; i < maxElem; first++)
    {
        for (int run = 0; run < elem.Length; run++)
        {
            int mask = 1, sum = 0;
            if ((i & mask) > 0) // ADD THIS LINE
            {
                sum += elem[run];                    
            }
            mask <<= 1;
        }
    }
