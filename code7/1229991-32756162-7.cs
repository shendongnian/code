    public class MyClass
    {
        public int Id { get; set; }
        public List<string> Names { get; protected set; } //notice I changed from IList to List
        public List<Types> ClassTypes { get; protected set; } //IList doesn't work out of the box
        public StatusType Status { get; set; }
        public MyClass()
        {
            Names = new List<string>();
            ClassTypes = new List<Types>();
            Status = StatusType.Active;
        }
    }
	
    public enum StatusType //notice I added XmlEnum attribute, to serialize as 0, 1
    {
        [XmlEnum(Name = "0")]
        Active = 0,
        [XmlEnum(Name = "1")]
        InActive = 1
    }
