    public class SearchVM
    {
        public string ClientID { get; set; }
        public string EmployeeID { get; set; }
        public IEnumerable<GroupVM> Groups { get; set; }
    }
