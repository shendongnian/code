    public class StrategyResult{
      public object Result{get;set;}
      public Type ResultType {get;set;}
     
      // frivolous examples
      public bool IsError {get;set;}
      public string ErrorMessage {get;set;}
    
      // really off-the-wall example
      public Func<StrategyHostContext,bool> ApplyResultToContext {get;set;}
      public StrategyResult(){
      }
      public StrategyResult FromStrategy(IStrategy strategy){
        return new StrategyResult{
          ResultType = strategy.ResultType
        } 
      }
      public StrategyResult FromStrategyExecute(IStrategy strategy, ISerializable info = null){
         var result = FromStrategy(strategy);
         try{
           strategy.Execute(info);
         } catch (Exception x){
           result.IsError = true;
           result.ErrorMessage = x.Message;
         }
      }
    }
