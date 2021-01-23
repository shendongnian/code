    public abstract class Operation
    {
          public Operation(Source sourceA, Source sourceB)
          {
               SourceA = sourceA;
               SourceB = sourceB;
          }
    
          public Source SourceA { get; }
          public Source SourceB { get; }
    
          public abstract int Do();
    }
    
    public class Add : Operation
    {
          public Operation(Source sourceA, Source sourceB) : base(sourceA, sourceB)
          {
          }
          
          public override int Do() => SourceA.Value + SourceB.Value;
    }
    
    public class Multiply : Operation
    {
          public Operation(Source sourceA, Source sourceB) : base(sourceA, sourceB)
          {
          }
          
          public override int Do() => SourceA.Value * SourceB.Value;
    }
