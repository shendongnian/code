    public class Product
    {
        public int Id { get; set; }
        public string ShortString { get; set; }
        public string LongString { get; set; }
        public bool ShouldSerializeLongString()
        {
            return (Id < 2);
        }
    }
