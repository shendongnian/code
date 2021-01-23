    public struct sOlder
    {
    	private struct MyData
    	{
    		public string Name { get; set; }
    		public int? Age { get; set; }
    		
    		public int CompareTo(MyData other)
    		{
    			if (Age == null) return other.Age == null ? 0 : -1;
    			if (other.Age == null) return 1;
    			return Age.Value.CompareTo(other.Age.Value);
    		}
    		
    		public static bool operator <(MyData left, MyData right)
    		{
    			return left.CompareTo(right) == -1;
    		}
    		
    		public static bool operator >(MyData left, MyData right)
    		{
    			return left.CompareTo(right) == 1;
    		}
    	}
    	
    	private MyData _eldestPerson;
    
        public void Init()
        {
    		_eldestPerson = default(MyData);
        }
    
        public void Accumulate(SqlString name, SqlInt32 age)
        {
            if (!name.IsNull && !age.IsNull)
            {
    			var currentPerson = new MyData
    			{
    				Name = name.Value,
    				Age = age.Value
    			};
    			
    			if (currentPerson > _eldestPerson)
    			{
    				_eldestPerson = currentPerson;
    			}
            }
        }
    
        public void Merge (sOlder other)
        {
            if (other._eldestPerson > _eldestPerson)
    		{
    			_eldestPerson = other._eldestPerson;
    		}
        }
    
        public SqlString Terminate()
        {
            return _eldestPerson.Name;
        }
    }
