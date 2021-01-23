    // How Can i ever be greater than 29 but also less than 30?
    for (int i = 0; i < 30; i++)
    {
        if (dataCaptured[i] != 0 && i < 29)
        {
            continue;
        }
    }
    
        public int Measure(int v, Units u)
        {
            if (v == 0)
            {
                throw new ArgumentOutOfRangeException("Your value of measuring was not in the specified range.");
            }
    
            if (false == (u == Units.Metric || u == Units.Imperial))
            {
                throw new ArgumentOutOfRangeException("Proper unit type not provided.");
            }
            mostRecentMeasure = v;
            if (u == Units.Metric || u == Units.Imperial)
            {
                unitsToUse = u;
                for (int i = 0; i < 30; i++)
                {
                    if (dataCaptured[i] != 0 && i < 29)
                    {
                        continue;
                    }
                    if (i == 29)
                    {
                        dataCaptured[i] = mostRecentMeasure;
                        return mostRecentMeasure;
                    }
                    dataCaptured[i] = mostRecentMeasure;
                    break;
                }
                return mostRecentMeasure;
            }
        }
