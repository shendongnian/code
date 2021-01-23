    class A
    {
      public virtual int Number { get; set; }
    }
    
    class B : A
    {
      public override int Number
      {
        get { return base.Number; }
        set { throw new InvalidOperationException("B.Number is readonly!"); }
      }
    }
    B b = new B();
    b.Number = 42; // BAM!
