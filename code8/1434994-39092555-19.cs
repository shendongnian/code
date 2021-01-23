<!-- -->
    public void Set(ulong uu) {
      uint uHi = NumericsHelpers.GetHi(uu);
      if (uHi == 0) {
        _uSmall = NumericsHelpers.GetLo(uu);
        _iuLast = 0;
      }
      else {
        SetSizeLazy(2);
        _rgu[0] = (uint)uu;
        _rgu[1] = uHi;
      }
      AssertValid(true);
    }
