    static class Program
    {
        const int column_width = 12;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Type code here.
            var xvec = new DenseVector(new double[] { 0.0, 1.0, 2.0, 3.0, 4.0 });
            var yvec = new DenseVector(new double[] { 3.0, 2.7, 2.2, 1.6, 0.2 });
            CubicSpline cs = CubicSpline.InterpolateNatural(xvec, yvec);
            Console.WriteLine($"{"x",column_width} {"y",column_width} {"dy/dx",column_width}");
            for(int i = 0; i < xvec.Count; i++)
            {
                double dydx = cs.Differentiate(xvec[i]);
                Console.WriteLine($"{xvec[i],column_width:G5} {yvec[i],column_width:G5} {dydx,column_width:G5}");
            }
        }
    }
