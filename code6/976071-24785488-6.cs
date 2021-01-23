    void GetMinMax(IList<double> list, out double min, out double max)
    {
        // TODO: null/empty check for list.
        min = Double.MaxValue;
        max = Double.MinValue;
        for (int i = 0; i < list.Count; ++i)
        {
            if (list[i] > max) max = list[i];
            if (list[i] < min) min = list[i];
        }
    }
