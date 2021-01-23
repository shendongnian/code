    public abstract class BaseRequestWrapperResponse 
    {
    	public IRequestFromResponse Request { get; set; }
    }
    public abstract class BaseRequestWrapperResponse<TRequest> : BaseRequestWrapperResponse where TRequest : IRequestFromResponse
    {
        public new TRequest Request
    	{
    		get{ return (TRequest)base.Request; }
    		set{ base.Request = value; }
    	}
    }
