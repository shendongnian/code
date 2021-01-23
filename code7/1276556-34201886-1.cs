    public class CustomerResult
    {
        public string CustomerName { get; set; }
        public string AddressTown { get; set; }
        public string JobStatusName { get; set; }
    }
    ...
    select new CustomerResult
    {
        CustomerName = j.CustomerName,
        AddressTown = c.AddressTown,
        JobStatusName = js.JobStatusName
    };
