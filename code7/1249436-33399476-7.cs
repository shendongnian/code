    [assembly:AddinStrategy(typeof(BoolStrategy))] // note it's outside the namespace
    namespace MyNamespace{
        public class BoolStrategy: IStrategy{
          public Type ResultType { get{ return typeof(bool);}}
          public void Initialize (SomeContextClassMaybe context){
          }
          public StrategyResult Execute(ISerializable info = null){
            return StrategyResult.FromStrategyExecute(this,info);
          }
        }
    }
