    public class Employee
    {
        public string Id { get; set; }
        public decimal HourlyRate { get; set; }
        public Employee(string id, decimal hourlyRate)
        {
            Id = id;
            HourlyRate = hourlyRate;
        }
    }
