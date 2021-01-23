    [Serializable]
    public class Resource
    {
        public string resourceID { get; set; }
        public string resourceName { get; set; }
        public List<Customer> Customers { get; set; }
    }
    
    public class Customer
    {
        public string customerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
    
    public class Appointment
    {
        public string appointmentID { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
