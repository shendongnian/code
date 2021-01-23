	public class RfidData : BaseViewModel
	{
		public RfidData(Guid id)
		{
			Id = id;
		}
		public virtual int CollectorId { get; set; }
		public virtual DateTime CheckInTime { get; set; }
		public virtual string Name { get; set; }
		public virtual bool CheckedIn { get; set; }
		public virtual DateTime TimeStamp { get; set; }
		public virtual Guid Id { get; }
  	}
