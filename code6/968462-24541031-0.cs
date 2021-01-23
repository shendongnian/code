    public class Product
    {
        public int Id { get; set; }
        public virtual IEnumerable<Sample> Samples { get; set; }
        [NotMapped]
        public decimal Price
        {
            get { return Samples.OrderByDescending(x => x.TimeStamp).First().Price; }
        }
    }
    public class Sample
    {
        public int Id {get; set;}
        public decimal Price { get; set; }
        [Timestamp]
        public byte[] TimeStamp {get; set;}
    }
