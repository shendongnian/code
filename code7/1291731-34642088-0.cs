    public class RootObject
    {
        [Key]
        public int RootObjectId { get; set; }
        public string Name { get; set; }
    }
    [Table("AObjects")]
    public class AObject : RootObject
    {
        //Other fields
        public string AField { get; set; }
    }
    [Table("BObjects")]
    public class BObject : RootObject
    {
        //Other fields
        public string BField { get; set; }
    }
