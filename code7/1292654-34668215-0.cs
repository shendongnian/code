    class Test
    {
    	public List<int> Nums { get; set; }
    	
    	public Test()
    	{
    		this.Nums = new List<int>();
    	}
    	
    	public Test(int def) : this()
    	{
    		this.Nums.Add(def);
    	}
    }
