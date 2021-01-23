    public sealed class Precise
    {
      private interface IOperation
      {
        int Calculate(int value);
        IOperation Combine(IOperation next);
      }
      private sealed class NoOp : IOperation
      {
        public static NoOp Instance = new NoOp();
        public int Calculate(int value)
        {
          return value;
        }
        public IOperation Combine(IOperation next)
        {
          return next;
        }
      }
      private sealed class Combo : IOperation
      {
        private readonly IOperation _first;
        private readonly IOperation _second;
        public Combo(IOperation first, IOperation second)
        {
          _first = first;
          _second = second;
        }
        public int Calculate(int value)
        {
          return _second.Calculate(_first.Calculate(value));
        }
        public IOperation Combine(IOperation next)
        {
          return new Combo(_first, _second.Combine(next));
        }
      }
      private sealed class Mult : IOperation
      {
        private readonly int _multiplicand;
        public Mult(int multiplicand)
        {
          _multiplicand = multiplicand;
        }
        public int Calculate(int value)
        {
          return value * _multiplicand;
        }
        public int Multiplicand
        {
          get { return _multiplicand; }
        }
        public IOperation Combine(IOperation next)
        {
          var nextMult = next as Mult;
          if(nextMult != null)
            return new Mult(_multiplicand * nextMult._multiplicand);
          var nextDiv = next as Div;
          if(nextDiv != null)
          {
            int divisor = nextDiv.Divisor;
            if(divisor == _multiplicand)
              return NoOp.Instance;//multiplcation by 1
            if(divisor > _multiplicand)
            {
              if(divisor % _multiplicand == 0)
                return new Div(divisor / _multiplicand);
            }
            if(_multiplicand % divisor == 0)
              return new Mult(_multiplicand / divisor);
          }
          return new Combo(this, next);
        }
      }
      private sealed class Div : IOperation
      {
        private readonly int _divisor;
        public Div(int divisor)
        {
          _divisor = divisor;
        }
        public int Divisor
        {
          get { return _divisor; }
        }
        public int Calculate(int value)
        {
          int ret = value / _divisor;
          if(value != ret * _divisor)
            throw new InvalidOperationException("Imprecise division");
          return ret;
        }
        public IOperation Combine(IOperation next)
        {
          var nextDiv = next as Div;
          if(nextDiv != null)
            return new Div(_divisor * nextDiv._divisor);
          var nextMult = next as Mult;
          if(nextMult != null)
          {
            var multiplicand = nextMult.Multiplicand;
            if(multiplicand == _divisor)
              return NoOp.Instance;
            if(multiplicand > _divisor)
            {
              if(multiplicand % _divisor == 0)
                return new Mult(multiplicand / _divisor);
            }
            else if(_divisor % multiplicand == 0)
              return new Div(multiplicand / _divisor);
          }
          return new Combo(this, next);
        }
      }
      private sealed class Plus : IOperation
      {
        private readonly int _addend;
        public Plus(int addend)
        {
          _addend = addend;
        }
        public int Calculate(int value)
        {
          return value + _addend;
        }
        public IOperation Combine(IOperation next)
        {
          var nextPlus = next as Plus;
          if(nextPlus != null)
          {
            int newAdd = _addend + nextPlus._addend;
            return newAdd == 0 ? (IOperation)NoOp.Instance : new Plus(newAdd);
          }
          return new Combo(this, next);
        }
      }
      private readonly int _value;
      private readonly IOperation _operation;
      public static Precise Zero = new Precise(0);
      private Precise(int value, IOperation operation)
      {
        _value = value;
        _operation = operation;
      }
      public Precise(int value)
        : this(value, NoOp.Instance)
      {
      }
      public int GetNumber()
      {
        return _operation.Calculate(_value);
      }
      public static explicit operator int(Precise value)
      {
        return value.GetNumber();
      }
      public static implicit operator Precise(int value)
      {
        return new Precise(value);
      }
      public override string ToString()
      {
        return GetNumber().ToString();
      }
      public Precise Multiply(int multiplicand)
      {
        if(multiplicand == 0)
          return Zero;
        return new Precise(_value, _operation.Combine(new Mult(multiplicand)));
      }
      public static Precise operator * (Precise precise, int value)
      {
        return precise.Multiply(value);
      }
      public Precise Divide(int divisor)
      {
        return new Precise(_value, _operation.Combine(new Div(divisor)));
      }
      public static Precise operator / (Precise precise, int value)
      {
        return precise.Divide(value);
      }
      public Precise Add(int addend)
      {
        return new Precise(_value, _operation.Combine(new Plus(addend)));
      }
      public Precise Subtract(int minuend)
      {
        return Add(-minuend);
      }
      public static Precise operator + (Precise precise, int value)
      {
        return precise.Add(value);
      }
      public static Precise operator - (Precise precise, int value)
      {
        return precise.Subtract(value);
      }
    }
