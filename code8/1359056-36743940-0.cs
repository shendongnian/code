    public class FractionArrayBuilder
    {
      private readonly List<Fraction> _fractions = new List<Fraction>();
    
      public FractionArrayBuilder Add(this FractionArrayBuilder b, int n, int d)
      {
        _fractions.Add(new Fraction(n, d);
        return b;
      }
    
      public Fraction[] Build()
      {
        return _fractions.ToArray();
      }
    }
