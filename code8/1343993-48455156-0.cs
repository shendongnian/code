    [ServiceContract(Name = "IProductService")]
    public interface IProductServiceAsync
    {
        [OperationContract]
        Task<Product> GetAsync(int id);
    }
