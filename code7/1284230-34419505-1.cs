    public class Employee
    {
        public string name;
        [JsonConverter(typeof(MyConverter))]
        public DateTime startDate;
    }
