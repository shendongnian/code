    public class Program
    {
        public void Main(string[] args)
        {
            UserOrganization[] newuserorg = new UserOrganization[10];
            newuserorg[0] = new UserOrganization("test", "test", "test", "demo.com", "test", true, "test", "test", "test", "test");
        }
    }
    public class UserOrganization
    {
        public UserOrganization()
        {
        }
        public UserOrganization(string costCenter, string department, string description, string domain, string symbol, bool primary, string title ,string type , string name, string location)
        {
            CostCenter = costCenter;
            Department = department;
            Description = description;
            Domain = domain;
            Symbol = symbol;
            Primary = primary;
            Title = title;
            Type = type;
            Name = name;
            Location = location;
        }
        public string Name { get; set; }
        public string CostCenter { get; internal set; }
        public string Department { get; internal set; }
        public string Description { get; internal set; }
        public string Domain { get; internal set; }
        public string Symbol { get; internal set; }
        public bool Primary { get; internal set; }
        public string Title { get; internal set; }
        public string Type { get; internal set; }
        public string Location { get; internal set; }
    }
