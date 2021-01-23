    public class InvoiceService
    {
       private IInvoiceRepositoryService RepositoryService;
       public SQLInvoiceService(IInvoiceRepositoryService _RS)
       {
           RepositoryService=_RS;
       }
    }
