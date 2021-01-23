    [ServiceContract(CallbackContract = typeof(ICallbackService))]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void GetDateTime();
    }
    public interface ICallbackService
    {
        [OperationContract(IsOneWay = true)]
        void GetDateTimeCompleted(DateTime dateTime);
    }
    public class Service : IService
    {
        public void GetDateTime()
        {
            // Do long action here.
            ...
            Callback.GetDateTimeCompleted(DateTime.Now);
        } 
        ICallbackService Callback
        {
            return OperationContext.Current.GetCallbackChannel<ICallbackService>();
        }
    }
