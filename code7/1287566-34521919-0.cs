    void Main()
    {
        var list = new List<Something>();
        for(int i=0; i<100; i++)
            list.Add(new Something { Value = i });
    
        var result = list.Where(p => p.Value < 50).Take(3);
        result.Count().Dump();
    }
    
	public class Something
    {
        private int _value;
        public int Value 
        {
            get { _value.Dump(); return _value; }
            set { _value = value; }
        }
    }
