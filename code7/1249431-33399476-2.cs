    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AddinStrategyAttribute : Attribute
    {
      public Type StategyType {get; private set;}
      public AddinStrategyAttribute(Type strategyType){
       StrategyType = strategyType;
      }
    }
