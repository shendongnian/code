    [ServiceContract(Namespace = "yourNamespace")]
    public interface IService
    {
        [FaultContractAttribute(
            typeof(CustomFault),
            Action = "", 
            Name = "Fault", 
            Namespace = "yourNamespace")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [OperationContract]
        Response Operation(Request request);
    }
