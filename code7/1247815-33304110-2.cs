    static class IsAlternatively
    {
      public static AlternativeEqualConstraint EqualTo(Record r)
      {
        return new AlternativeEqualConstraint(r);
      }
    }
    class AlternativeEqualConstraint : NUnit.Framework.Constraints.Constraint
    {
      readonly Record expected;
      double tolerance;
      public AlternativeEqualConstraint(Record r)
      {
        this.expected = r;
      }
      public AlternativeEqualConstraint Within(double tolerance)
      {
        this.tolerance = tolerance;
        return this;
      }
      public override bool Matches(object obj)
      {
        actual = obj;
        if (!(obj is Record))
          return false;
        var other = (Record)obj;
        return Math.Abs(other.P1 - expected.P1) < tolerance && Math.Abs(other.P2 - expected.P2) < tolerance;
      }
      public override void WriteDescriptionTo(NUnit.Framework.Constraints.MessageWriter writer)
      {
        writer.WriteExpectedValue(expected);
        writer.WriteMessageLine("Expected within tolerance '{0}'.", tolerance);
      }
      public override void WriteActualValueTo(NUnit.Framework.Constraints.MessageWriter writer)
      {
        writer.WriteActualValue(actual);
      }
    }
