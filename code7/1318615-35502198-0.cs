    [DataContract]
    public class ServiceResponse
    {
        [DataMember]
        public ServiceStatus Status { get; set; }
    }
    
    [DataContract]
    public class SettingsAcceptedResponse : ServiceResponse
    {
        [DataMember]
        public bool Result { get; set; }
    }
    
    [ServiceContract]
    public interface IService
    {
        // [...] 
    
        [OperationContract]
        ServiceResponse SetSettings(Settings settings);
    
        [OperationContract]
        SettingsAcceptedResponse SettingsAccepted();
    }
