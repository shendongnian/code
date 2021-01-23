        for (int i = 0; i < numberPool.Length; i++)
        {
                if (numberPool[i] % 3 == 0 || numberPool[i] % 5 == 0)
                {
                    // Do nothing
                }
                else
                {
                    numberPool[i] = 0;
                }
        }
