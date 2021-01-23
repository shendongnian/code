    class Program
    {
    	static void Main(string[] args)
    	{
    		var anon = new { Name = "Yuval", Age = 1 };
    		var result = JsonConvertEx.SerializeObject(anon);
    	}
    }
