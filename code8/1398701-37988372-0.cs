    public static void FitCircle(IEnumerable<Point> points, out double x0, out double y0, out double r)
    {
        setMklProvider();
        DenseMatrix A = DenseMatrix.Create(3, 3, (i, j) => 0);
        DenseMatrix b = DenseMatrix.Create(3, 1, (i, j) => 0);
        A[0, 0] = points.Sum(point => point.X * point.X);
        A[0, 1] = points.Sum(point => point.X * point.Y);
        A[0, 2] = points.Sum(point => point.X);
        A[1, 0] = A[0, 1];
        A[1, 1] = points.Sum(point => point.Y * point.Y);
        A[1, 2] = points.Sum(point => point.Y);
        A[2, 0] = A[0, 2];
        A[2, 1] = A[1, 2];
        A[2, 2] = points.Count();
        b[0, 0] = points.Sum(point => point.X * (point.X * point.X + point.Y * point.Y));
        b[1, 0] = points.Sum(point => point.Y * (point.X * point.X + point.Y * point.Y));
        b[2, 0] = points.Sum(point => point.X * point.X + point.Y * point.Y);
        var x = A.QR().Solve(b);
        x0 = x[0, 0] / 2;
        y0 = x[1, 0] / 2;
        r = Math.Sqrt(x[2, 0] + x0 * x0 + y0 * y0);
    }
    private static void setMklProvider()
    {
        if (!_mklProviderSet) MathNet.Numerics.Control.LinearAlgebraProvider = new MathNet.Numerics.Algorithms.LinearAlgebra.Mkl.MklLinearAlgebraProvider();
    }
