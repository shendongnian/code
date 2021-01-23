    class Z
    {
    	public TimeSpan Time { get; set; }
    };
    
    class Program
    {
    
    	static void Main(string[] args)
    	{
    		Random rand = new Random();
    		List<Z> zs = new List<Z>();
    		for (int i = 0; i < 10; i++)
    		{
    			zs.Add(new Z { Time = new TimeSpan(i, rand.Next(0,61), rand.Next(0,61)) });
    		}
    
    		TimeSpan threshold = new TimeSpan(4,0,0);
    		var newThings = zs.Skip(zs.FindIndex(x => x.Time >= threshold) - 1);
    		Console.WriteLine(string.Join(", ", newThings.Select(x => x.Time.ToString("c"))));
    
    		Console.ReadLine();
    
    	}
    }
