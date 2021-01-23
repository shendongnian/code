    public class SalesService : Service<Sales>, ISalesService.cs
    {
       private readonly IRepositoryAsync<Sales> _repository;
       // This is the constructor WCF uses
       public SalesService() : this(new ..)
       {
       }
       public SalesService(IRepositoryAsync<Sales> repository)
       {
          _repository = repository;
       }
    }
