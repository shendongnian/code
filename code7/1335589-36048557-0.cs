	public class RkeeperV7MenuRecord : DefaultEntityRecord {
		public virtual int SpotId { get; set; }
		public virtual DateTime Date { get; set; }
		[StringLengthMax]
		public virtual string OriginalData { get; set; }
	}
