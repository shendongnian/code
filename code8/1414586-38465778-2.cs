    class ListBillsViewModel {
        private IBillHandlingService _billHandlingService;
        private ISettingsService _settingsService;
        public ListBillsViewModel(IBillHandlingService billHandlingService, ISettingsService settingsService) {
            this._billHandlingService = billHandlingService;
            this._settingsService = settingsService;
            BillsList = new List<IBillItem>();
        }
        public List<IBillItem> BillsList { get; set; }
        public async Task GetBillsAsync() {
            BillsList.Clear();
            var bills = await _billHandlingService.GetAllBillsAsync(_settingsService.LoggerUserName);
            if (null != bills) {
                var billsByDate = bills.Where(x => x.DueDate == DateTime.Today).ToList();
                foreach (var bill in billsByDate) {
                    BillsList.Add(bill);
                }
            }
        }
    }
    public interface ISettingsService {
        string Name { get; }
        string LoggerUserName { get; set; }
    }
    public interface IBillHandlingService {
        Task<List<IBillItem>> GetAllBillsAsync(string username);
    }
    public class BillItem : IBillItem {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Name { get; set; }
        public string IndexNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
    }
    public interface IBillItem {
        int Id { get; set; }
        DateTime DueDate { get; set; }
        string Name { get; set; }
        string IndexNumber { get; set; }
        string AccountNumber { get; set; }
        decimal Amount { get; set; }
    }
