    abstract class Classification
    {
      public abstract string type();
    }
    
    class PartTime : Classification
    {
      public override string type() {...}
      public Job1() {...}
    }
    
    class FullTime : Classification
    {
      public override string type() {...}
      public Job2() {...}
    }
