	public class Step
	{
		public int divisor { get; set; }
		public int dividend { get; set; }
		public int product { get; set; }
		public int quotient { get; set; }
		public int remainder { get; set; }
	}
	public class StepsResponse
	{
		public Step[] Steps { get; set; } // It can be a List<Step>
	}
	// ... 
	JsonConvert.DeserializeObject<StepsResponse>(jsonString);
