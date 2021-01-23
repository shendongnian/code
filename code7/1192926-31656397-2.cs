    public sealed class CpuMask
    {
      private int _bits;
      
      public bool this[int index]
      {
        get { return (_bits & (1 << index)) > 0; }
        set { if (value) _bits |= (1 << index); else _bits &= ~(1 << index); }
      }
      
      public CpuMask(int mask)
      {
        _bits = mask;
      }
      
      public CpuMask(IntPtr mask) : this(mask.ToInt32()) { }
      
      public IntPtr ToIntPtr() { return new IntPtr(_bits); }
    }
