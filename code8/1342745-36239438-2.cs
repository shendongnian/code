    public class Invoice
    {
        public string Id
        { get; set; }
        public Dictionary<string, Line> Lines
        { get; set; }
    }
    public class Data
    {
        public Invoice Invoice
        { get; set; }
    }
