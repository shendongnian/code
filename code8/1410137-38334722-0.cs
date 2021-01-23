    public interface IResponse<TData,THeader>
    {
        THeader Header { get; set; }
        TData Data { get; set; }
    }
    
    public TOut CreateResponse<TOut, TIn,THeader>(TIn data) where TOut : IResponse<TIn,THeader>,new(), 
          THeader: new()
    {
        var response = new TOut();
        response.Header = new THeader();
        response.Data = data;
        return response;
    }
    
    var result = CreateResponse<ClientResponse, ClientData,GenericHeader>(new ClientData());
