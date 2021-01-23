    public class Type1 : IComparable<Type1>
    {
        public Int32 ID { get; set; }
        public Decimal Value { get; set; }
    	
    	public int CompareTo(Type1 obj) {
    		if (obj == null)
    			return -1;
    		return Value.CompareTo(obj.Value);
    	}
    }
