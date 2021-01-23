    public class responseWraper
    {
        public response response { get; set; }
    }
    public class response
    {
        public string status { get; set; }
        public content content { get; set; }
    }
    public class content
    {
        public Employees Employees { get; set; }
    }
    public class Employees
    {
        public string Employee_id { get; set; }
        public string Employee_name { get; set; }
        public string status { get; set; }
    }      
