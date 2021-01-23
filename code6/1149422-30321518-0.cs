    [ServiceContract(ConfigurationName = "Data.GetData")]
    public interface IService1
    {
       [OperationContract]
       DataTable GetADUserList(string strUserName, string strFirstName, string strLastName, string strEmail, string domain);
    }
