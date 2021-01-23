    public class Beer : IDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brewery { get; set; }
        public string Address { get; set; }
    }
    public class Brewery : IDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string City { get; set; }
    }
