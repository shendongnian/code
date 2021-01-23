    public interface IStrategy{
      Type ResultType {get;}
      void Initialize(SomeContextClassMaybe context);
      StrategyResult Execute(ISerializable info = null); 
    }
