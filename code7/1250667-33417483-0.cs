    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface ICalculator
    {
       [OperationContract(IsInitiating = True)]
       Bool Begin()
       [OperationContract(IsInitiating = false)]
       double Add(double n1, double n2)
    }
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class CalculatorService : ICalculator
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        public double Add(double n1, double n2)
        {
            var cancellationToken = cts.Token;
            var t = Task<double>.Factory.StartNew(() => { 
               // here you can do something long
               while(true){
               // and periodically check if task should be cancelled or not
               if(cancellationToken.IsCancellationRequested)
                 throw new OperationCanceledException();
               // or same in different words
               cancellationToken.ThrowIfCancellationRequested();
               }
               return n1 + n2;
            }, cancellationToken);
            return t.Result;
        }
        public Bool Begin(){}
    }
