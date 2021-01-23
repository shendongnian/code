    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IMessageService
    {
        [OperationContract(IsOneWay = true)]
        void AddMessageToSession(String msg);
        [OperationContract]
        List<String> ListSessionMessages();
    }
