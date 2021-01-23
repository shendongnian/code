    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MyService : IMyService
    {
        public void DoWork()
        {
            Console.WriteLine("Hello World");
            Callback.WorkComplete();
        }
        IMyServiceCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IMyServiceCallback>();
            }
        }
    }
