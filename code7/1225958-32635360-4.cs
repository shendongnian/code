    public void MethodNeedsToAdd(IAddition addCalculator)
    {
      if (addCalculator != null)
      {
        addCalculator.Add();
      }
    }
    MethodNeedsToAdd(one);   // Valid
    MethodNeedsToAdd(two);   // Invalid
