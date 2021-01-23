    class WeatherInfo {
          private static readonly int minDegree = -273;
          private static readonly int maxDegree = 75;
          private int degree;
          public int Degree {
             get {
                 return this.degree;
             }
             set {
                 if (value < minDegree || value > maxDegree) {
                     throw new ArgumentOutOfRangeException();
                 }
             }
          }
          ..
          ..
    }
