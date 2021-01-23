    interface IInvoice{
    }
    class ExpiredInvoices: IInvoice{
    }
    
    class ActiveInvoices: IInvoice{
    }
    public class SearchInvoices
    {
        public readonly IRepository<IInvoice> latestActiveInvoicesRepository;
    
        public SearchInvoices(IRepository<IInvoice> activeInvoicesRepository)
        {
            latestInvoicesRepository = activeInvoicesRepository;
        }
    
        public List<T> GetActiveInvoices<T>() where T: IInvoice
        {
            var listOfActiveInvoices = latestActiveInvoicesRepository.GetAll();
            return listOfActiveInvoices;
        }
    }
