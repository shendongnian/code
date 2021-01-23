	public class Adjustment
	{
		public string CardNumber { get; set; }
		public string TimeStamp { get; set; }
		public double Point { get; set; }
	}
	public class RootObject
	{
		public int Id { get; set; }
		public Adjustment Adjustment { get; set; }
	}
