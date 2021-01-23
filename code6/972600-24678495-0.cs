    public class Snapshot
    {
        public int ID { get; set; }
        public string Guid { get; set; }
        // ...
    }
    public class BrandEmailList : List<Snapshot>
    {
    }
