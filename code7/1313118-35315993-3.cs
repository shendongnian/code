	[ServiceContract]
	public interface IMyService
	{
		[OperationContract]
		ResultObject[] Search(SearchParams searchParams);
		[DataMember]
		MyCustomClass MyDataMember { get; }
	}
