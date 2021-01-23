    public class Session
	{
		[Key, ForeignKey("Device")]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }
		public virtual Device Device { get; set; }
	}
