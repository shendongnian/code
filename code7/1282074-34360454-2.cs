    int[] GetValues(long stored, int minValue, int maxValue, int valueCount);
    {
        // TODO: Do some parameter checking.
        int[] results = new int[valueCount];
        int rangeSize = maxValue - minValue + 1;
        for(int i = 0; i < valueCount; i++)
        {
            results[i] = rangeSize % diff + minValue;
            stored = stored / diff; 
        }
        return results;
    }
