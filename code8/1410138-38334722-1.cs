    public interface IResponse<TData,THeader>
    {
        THeader Header { get; set; }
        TData Data { get; set; }
    }
    
    public TOut CreateResponse<TOut, TIn,THeader>(TIn data) 
        where TOut : IResponse<TIn,THeader>,new(), THeader: new()
        => new TOut(){ Header = new THeader(), Data = data,};
        
    var result = CreateResponse<ClientResponse, ClientData,GenericHeader>(new ClientData());
