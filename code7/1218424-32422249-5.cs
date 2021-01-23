    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    public class MyProduct
    {
		[FieldOrder(0)]
        public string Name { get; set; }
		
		[FieldOrder(1)]
        public string Surname { get; set; }
		
		[FieldOrder(2)]
        public string Phone { get; set; }
		
		[FieldOrder(3)]
        public string Address { get; set; }
    }
