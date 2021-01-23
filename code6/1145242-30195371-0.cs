    public static float[][] Convert(double[][] mtx)
    {
        var floatMtx = new float[mtx.Length][];
        for (int i = 0; i < mtx.Length; i++)
        {
            floatMtx[i] = new float[mtx[i].Length];
            for (int j = 0; j < mtx[i].Length; j++)
                floatMtx[i][j] = (float)mtx[i][j];
        }
        return floatMtx;
    }
    Or:
    
    public static float[][] Convert(double[][] mtx)
    {
        return mtx.Select(i => i.Select(j => (float)j).ToArray()).ToArray();
    }
