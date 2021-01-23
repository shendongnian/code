    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface Iservice
    {
       // you do not need really to return anything
       [OperationContract(IsInitiating = True, IsOneWay=true)]
       void Login(UserData user)
    
       [OperationContract(IsInitiating = false)]
       double ProcessData(double n1, double n2)
       // your implementation can do some finalization or even can be empty.
       // the call will simply drop the session
       [OperationContract(IsInitiating = False, IsTerminating =True, IsOneWay=True)]
       void Logout()
    }
