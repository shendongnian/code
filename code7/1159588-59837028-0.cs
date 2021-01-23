[MessageContract(IsWrapped = true)]
public class ParameterClass
{
    [MessageBodyMember]
    public string InformationType { get; set; }
    [MessageBodyMember]
    public string ItemLocation { get; set; }
}
