    [ServiceContract]
    public interface IInterface
    {
        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare)]
        ObjAPI GetAPIRequest(ObjAPI objAPI)
    }
    public class Service: IInterface
    {
        public ObjAPI GetAPIRequest(ObjAPI objAPI)
        {
           return new ExternalAPI().GetAPIRequest(objAPI);
        }
    }
    [System.Runtime.Serialization.DataContract(Namespace = "")]
    public class ObjAPI
    {
        [System.Runtime.Serialization.DataMember]        
        public int ID { get; set; }   
        [System.Runtime.Serialization.DataMember]
        public Client Client { get; set; }       
    }
