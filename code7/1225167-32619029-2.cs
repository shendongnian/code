    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        DateTime GetDateTime();
    }
    public class Service : IService
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
