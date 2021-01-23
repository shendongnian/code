    public struct DataResult
    {
        private string _raw;
        public DataResult(string raw)
        {
            _raw = raw;
        }
        public string Raw { get { return _raw; } }
    
    	public static implicit operator string(DataResult result)
    	{
    		return result.Raw;	
    	}
    	
    	public static implicit operator DataResult(string rawResult)
    	{
    		return new DataResult(rawResult);
    	}
    	
         public static implicit operator string[](DataResult result)
         {
    		 return new [] { result.Raw };
         }
    	
    	public static implicit operator DataResult(string[] rawResultArray)
    	{
    		if(rawResultArray == null || rawResultArray.Length != 1)
    			throw new ArgumentException("Raw result must be a single item array", "rawResultArray");
    		
    		return new DataResult(rawResultArray[0]);
    	}
    }
