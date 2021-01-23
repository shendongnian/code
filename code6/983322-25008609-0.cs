	public class LDAVehicle	
    {
		public virtual int VehicleId { get; set; }
		public virtual string ChassisSeries { get; set; }
		public virtual string ChassisNumber { get; set; }
		//public virtual List<LDAReading> Readings { get; set; }
        public virtual IList<LDAReading> Readings { get; set; }
	}
	public class LDAReading	
    {
		public virtual int ReadingId { get; set; }
		public virtual DateTime IncomingDate { get; set; }
		public virtual DateTime ReadoutDate { get; set; }
		public virtual string Sender { get; set; }
		public virtual LDAVehicle Vehicle { get; set; }
	}
