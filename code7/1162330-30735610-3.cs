    [DataContract(Name = "authenticateResponse")]
    [MessageContract(WrapperName = "authenticateResponse", IsWrapped = true)]
    public class AuthenticateResponse
    {
    	[DataMember(Name = "authenticateResult", IsRequired = true)]
    	[MessageBodyMember(Name = "authenticateResult", Order = 1)]
    	public ArrayOfString AuthenticateResult { get; set; }
    
    	public AuthenticateResponse()
    	{
    		this.AuthenticateResult = new ArrayOfString();
    	}
    
    	public AuthenticateResponse(ArrayOfString authenticateResult)
    	{
    		this.AuthenticateResult = authenticateResult;
    	}
    }
