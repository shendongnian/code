    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        String Hello(String Name);
        [OperationContract]
        Person GetPerson();
    }
