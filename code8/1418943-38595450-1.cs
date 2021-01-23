    public class EmployeeNewspaper
    {
        [Key][Column(Order = 0)]
        public string Name { get; set; }
        [Key][Column(Order = 1)]
        public string Appendage { get; set; }
        public string SourceInformationName { get; set; }
    }
