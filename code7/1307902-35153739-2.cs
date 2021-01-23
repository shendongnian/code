    public SomeType SomeValue
    {
      get
      {
        if (_backingField == null)
          _backingField = RelativelyLengthyCalculationOrRetrieval();
        return _backingField;
      }
    }
