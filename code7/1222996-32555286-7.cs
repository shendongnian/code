    public class SearchInvoices<T> where T: IInvoice
    {
        public readonly IRepository<T> latestActiveInvoicesRepository;
    
        public SearchInvoices(IRepository<T> activeInvoicesRepository)
        {
            latestInvoicesRepository = activeInvoicesRepository;
        }
    
        public List<T> GetActiveInvoices() 
        {
            var listOfActiveInvoices = latestActiveInvoicesRepository.GetAll();
            return listOfActiveInvoices;
        }
    }
