        public static double GetAbsoluteMax(double[] xs, double[] ys)
        {
            double maxDistanceSqd = 0;
                
            int nPts = xs.Length;
            for ( int i =0; i < nPts ; ++i )
            {
                double x1 = xs[i];
                double y1 = ys[i];
                for (int j = 0; j < nPts; ++j)
                {
                    double deltaX = x1 - xs[j];
                    double deltaY = y1 - ys[j];
                    double distsqd = (deltaX * deltaX + deltaY * deltaY);
                    if (distsqd > maxDistanceSqd)
                    {
                        maxDistanceSqd = distsqd;
                    }
                }
            }
            return Math.Sqrt(maxDistanceSqd);
        }
