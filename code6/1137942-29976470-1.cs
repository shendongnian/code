	public class City
	{
		public long ID { get; set }
		...
		[NonSerialized()]
		public State State { get; set; }
		...
	}
