      private static double Correlation(IEnumerable<Double> xs, IEnumerable<Double> ys) {
        // sums of x, y, x squared etc.
        double sx = 0.0;
        double sy = 0.0;
        double sxx = 0.0;
        double syy = 0.0;
        double sxy = 0.0;
    
        int n = 0;
    
        using (var enX = xs.GetEnumerator()) {
          using (var enY = ys.GetEnumerator()) {
            while (enX.MoveNext() && enY.MoveNext()) {
              double x = enX.Current;
              double y = enY.Current;
    
              n += 1;
              sx += x;
              sy += y;
              sxx += x * x;
              syy += y * y;
              sxy += x * y;
            }
          }
        }
    
        // covariation
        double cov = sxy / n - sx * sy / n / n;
        // standard error of x
        double sigmaX = Math.Sqrt(sxx / n -  sx * sx / n / n);
        // standard error of y
        double sigmaY = Math.Sqrt(syy / n -  sy * sy / n / n);
    
        // correlation is just a normalized covariation
        return cov / sigmaX / sigmaY;
      }
