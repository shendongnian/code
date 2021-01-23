    public static Matrix<double[,]> BuildMetaMatrix()
    {
        Matrix<double[,]> m = new Matrix<double[,]>(2, 2);
        m[0, 0] = new double[,]
        {
            { 1 }
        };
        m[0, 1] = new double[,]
        {
            { 3, 3, 3 },
            { 3, 3, 3 },
            { 3, 3, 3 }
        };
        m[1, 0] = new double[,]
        {
            { 2, 2 },
            { 2, 2 }
        };
        m[1, 1] = new double[,]
        {
            {4, 4, 4, 4},
            {4, 4, 4, 4},
            {4, 4, 4, 4},
            {4, 4, 4, 4}
        };
        return m;
    }
