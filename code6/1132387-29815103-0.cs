	void Main()
	{
		Dictionary<int, double> deltas = new Dictionary<int, double>();
		int avg = 0;
		
		List<Item> dists = new List<Item>();
		for (int a = 0; a < deltas.Count(); a++)
		{
			dists.Add(new Item { Offset = Math.Abs(deltas[a] - avg), Time = deltas[a].ToDateTime()});
		}
	}
	
	public class Item 
	{
		public double Offset { get; set; }
		public DateTime Time { get; set; }
		public string DisplayString { get; set; }
		
		public override string ToString()
		{
			return string.Format("offset: {0}, time: {1}", this.Offset, this.Time);
		}
	}
	
	public static class Extension
	{
		public static DateTime ToDateTime(this double time)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(time);
		}
	}
	
