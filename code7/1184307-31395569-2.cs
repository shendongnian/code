    public class SalesService : Service<Sales>, ISalesService.cs
    {
       private readonly IRepositoryAsync<Sales> _repository;
       // This is the constructor WCF's default factory calls
       public SalesService() : this(new ..)
       {
       }
       public SalesService(IRepositoryAsync<Sales> repository)
       {
          _repository = repository;
       }
    }
