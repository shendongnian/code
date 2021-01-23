    public class Type1 : IComparable
    {
        public Int32 ID { get; set; }
        public Decimal Value { get; set; }
    	
    	public int CompareTo(object obj) {
    		var castObj = obj as Type1;
    		if (castObj == null)
    			return -1;
    		return Value.CompareTo(castObj.Value);
    	}
    }
