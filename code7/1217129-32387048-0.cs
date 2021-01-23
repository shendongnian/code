    abstract class A
    {
        public abstract Image Symbol{get;}
    }
    class B:A
    {
    
      private static readonly Image _symbol = ...
    
      public override Image Symbol{get{return _symbol;}}
    }
