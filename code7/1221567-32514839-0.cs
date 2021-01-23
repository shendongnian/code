    public class Detail
    {
        public string Status { get; set; }
        public string Name { get; set; }
    }
    public class Report
    {
        public string ID { get; set; }
        public string Age { get; set; }
        public List<Detail> Details { get; set; }
    }
    public class RootObject
    {
        public List<Report> Report { get; set; }
    }
