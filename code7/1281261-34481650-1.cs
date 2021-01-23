    /// <summary>
    /// DTW Algotithm with Pruning
    /// Only Sakoe-Chiba band is caluculated and the rest is pruned
    /// </summary>
    float Pruning_DTWDistance(Sequence input, Sequence output)
    {
        int rows = input.Frames.Length, columns = output.Frames.Length;
        if (rows < (double)(columns / 2) || columns < (double)(rows / 2))
        {
            return float.MaxValue;
        }
        float cost;
        float[,] DTW = new float[rows + 1, columns + 1];
        int w = Math.Abs(columns - rows);// window length -> |rows - columns|<= w
        for (int i = 1; i <= rows; i++)
        {
            for (int j = Math.Max(1, i - w); j <= Math.Min(columns, i + w); j++)
            {
                if (DTW[i - 1, j] == 0)
                    DTW[i - 1, j] = float.MaxValue;
                if (DTW[i - 1, j - 1] == 0)
                    DTW[i - 1, j - 1] = float.MaxValue;
                DTW[0, 0] = 0;
                cost = distance(input.Frames[i - 1], output.Frames[j - 1]);// frames 0 based
                DTW[i, j] = (cost + Math.Min(DTW[i - 1, j], DTW[i - 1, j - 1]));// insert ,match
            }
        }
        return DTW[rows, columns];
    }
