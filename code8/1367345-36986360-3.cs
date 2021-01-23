    [ServiceContract]
    [ServiceKnownType(typeof(List<StageContract>))]
    public interface IUserService
    {
        [OperationContract]
        void CreateUser(string name, string pwd, bool admin);
        [OperationContract]
        bool LogInUser(string name, string pwd);
        [OperationContract]
        List<StageContract> getAllStages();
    }
