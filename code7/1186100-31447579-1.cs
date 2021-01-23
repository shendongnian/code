    public void Meth<T>(T enumValue) where T : struct
    {
      InternalMeth((dynamic)enumValue);
    }
    private void InternalMeth(FirstEnumType enumValue)
    {
      this.helperFirstCalcBll(enumValue);
    }
    private void InternalMeth(SecondEnumType enumValue)
    {
      this.helperSecondCalcBll(enumValue);
    }
    private void InternalMeth(object enumValue)
    {
      // Do whatever fallback you need
    }
