    public void Meth<T>(T enum) where T : struct
    {
      InternalMeth((dynamic)enum);
    }
    private void InternalMeth(FirstEnumType enum)
    {
      this.helperFirstCalcBll(enum);
    }
    private void InternalMeth(SecondEnumType enum)
    {
      this.helperSecondCalcBll(enum);
    }
    private void InternalMeth(object enum)
    {
      // Do whatever fallback you need
    }
