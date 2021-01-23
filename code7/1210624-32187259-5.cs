    public class SharedData
    {
        public string Meta { get; set; }
        public int Value { get; set; }
    	
        public SharedData(string meta, int value)
        {
            Meta = meta;
            Value = value;
        }
    }
    public class DerivedData : SharedData
    {
        public string Test
    	{
    		get { return string.Format("Shared meta = {0}, Shared Value = {1}", Meta, Value); }
    	}
    
    
    	public DerivedData(string meta, int value) : base(meta, value)
        {
    	}
    
    	// note: this is a copy ctor, changing data after this has been created, will not affect this.
    	public DerivedData(SharedData data) : base(data.Meta, data.Value)
    	{
    	}
    }
