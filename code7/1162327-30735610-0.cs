    [ServiceContract(Namespace = QuickBooks.URL, Name = "QuickBooks")]
    public interface IQuickBooks
    {
    	[OperationContract(Action = QuickBooks.URL + "authenticate")]
    	AuthenticateResponse authenticate(Authenticate authenticateSoapIn);
    }
