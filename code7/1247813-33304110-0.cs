    class IsAlternatively
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
      Record actual;
      public AlternativeEqualConstraint(Record r)
      {
        expected = r;
      }
      public AlternativeEqualConstraint Within(double tolerance)
      {
        this.tolerance = tolerance;
        return this;
      }
      public override bool Matches(object obj)
      {
        if (!(obj is Record))
          return false;
        actual = (Record)obj;
        return Math.Abs(actual.P1 - expected.P1) < tolerance && Math.Abs(actual.P2 - expected.P2) < tolerance;
      }
      public override void WriteDescriptionTo(NUnit.Framework.Constraints.MessageWriter writer)
      {
        // must improve below description
        writer.WriteExpectedValue(expected);
        writer.WriteActualValue(actual);
        writer.WriteMessageLine("Expected within tolerance '{0}'.", tolerance);
      }
    }
