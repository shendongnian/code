    [ServiceContract]
    public interface IBankAccountService {
        [OperationContract]
        BankAccountModel Insert( BankAccountModel item );
    
        [OperationContract]
        BankAccountModel Update( BankAccountModel item  );
        
        [OperationContract]
        void Delete(string ID); 
        //... interface of other methods
    }
