    public class Temporary : ICompany
    {
        public string Name { get; set; }
    }
    public class Company : ICompany
    {
        public string Name { get; set; }
        public string OtherProperty {get; set;}
    }
