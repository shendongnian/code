    static class Program
    {
        const int column_width = 12;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0 });
            var yvec = new DenseVector(new double[] { 3.0, 2.7, 2.3, 1.6, 0.2 });
            Debug.WriteLine("Input Data Table");
            Debug.WriteLine($"{"x",column_width} {"y",column_width}");
            for(int i = 0; i < xvec.Count; i++)
            {
                Debug.WriteLine($"{xvec[i],column_width:G5} {yvec[i],column_width:G5}");
            }
            Debug.WriteLine(" ");
            var cs = CubicSpline.InterpolateNatural(xvec, yvec);
            var x = new DenseVector(15);
            var y = new DenseVector(x.Count);
            var dydx = new DenseVector(x.Count);
            Debug.WriteLine("Interpoaltion Results Table");
            Debug.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            for(int i = 0; i < x.Count; i++)
            {
                x[i] = (4.0*i)/(x.Count-1);
                y[i] = cs.Interpolate(x[i]);
                dydx[i] = cs.Differentiate(x[i]);
                Debug.WriteLine($"{x[i],column_width:G5} {y[i],column_width:G5} {dydx[i],column_width:G5}");
            }
        }
    }
