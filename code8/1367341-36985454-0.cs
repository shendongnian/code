    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void CreateUser(string name, string pwd, bool admin);
    
        [OperationContract]
        bool LogInUser(string name, string pwd);
    
        [OperationContract]
        List<StageContract> getAllStages();
    }
    public List<StageContract> getAllStages()
    {
      return (new StageController())
         .getAllStages()
         .Values
         .Select(s => new StageContract(s))
         .ToList();
    }
