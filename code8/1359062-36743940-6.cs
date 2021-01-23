    public class FractionArrayBuilder
    {
      private readonly List<Fraction> _fractions = new List<Fraction>();
    
      public FractionArrayBuilder Add(int n, int d)
      {
        _fractions.Add(new Fraction(n, d));
        return this;
      }
    
      public Fraction[] Build()
      {
        return _fractions.ToArray();
      }
    }
