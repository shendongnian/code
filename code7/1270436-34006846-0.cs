    public class ModelBase
    {
    }
    public class MyModel1 : ModelBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ClientAddress Address { get; set; }
    }
    public class MyModel2 : ModelBase
    {
        public string CompanyName { get; set; }
        public string Region { get; set; }
        public CompanyAddress Address { get; set; }
    }
    public class ClientAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
    }
    public class CompanyAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public List<string> AdditionalLines { get; set; }
    }
