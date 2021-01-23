    public static double[,] KernelDensityEstimation(double[] data, double sigma, int nsteps)
        {
            // probability density function (PDF) signal analysis
            // Works like ksdensity in mathlab. 
            // KDE performs kernel density estimation (KDE)on one - dimensional data
            // http://en.wikipedia.org/wiki/Kernel_density_estimation
            // Input:	-data: input data, one-dimensional
            //          -sigma: bandwidth(sometimes called "h")
            //          -nsteps: optional number of abscis points.If nsteps is an
            //          array, the abscis points will be taken directly from it. (default 100)
            // Output:	-x: equispaced abscis points
            //          -y: estimates of p(x)
            // This function is part of the Kernel Methods Toolbox(KMBOX) for MATLAB. 
            // http://sourceforge.net/p/kmbox
            // Converted to C# code by ksandric
            double[,] result = new double[nsteps, 2];
            double[] x = new double[nsteps], y = new double[nsteps];
            double MAX = Double.MinValue, MIN = Double.MaxValue;
            int N = data.Length; // number of data points
            // Find MIN MAX values in data
            for (int i = 0; i < N; i++)
            {
                if (MAX < data[i])
                {
                    MAX = data[i];
                }
                if (MIN > data[i])
                {
                    MIN = data[i];
                }
            }
            // Like MATLAB linspace(MIN, MAX, nsteps);
            x[0] = MIN;
            for (int i = 1; i < nsteps; i++)
            {
                x[i] = x[i - 1] + ((MAX - MIN) / nsteps);
            }
            // kernel density estimation
            double c = 1.0 / (Math.Sqrt(2 * Math.PI * sigma * sigma));
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < nsteps; j++)
                {
                    y[j] = y[j] + 1.0 / N * c * Math.Exp(-(data[i] - x[j]) * (data[i] - x[j]) / (2 * sigma * sigma));
                }
            }
            // compilation of the X,Y to result. Good for creating plot(x, y)
            for (int i = 0; i < nsteps; i++)
            {
                result[i, 0] = x[i];
                result[i, 1] = y[i];
            }
            return result;
        }
