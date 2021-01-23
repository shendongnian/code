	public class Entity
	{
		public long ID { get; set; }
	}
	public class Doctor : Entity
	{
		public string Name {get; set;}
		public string sprcialization { get; set;}
		[InverseProperty("Doctor")]
		public string Icollection<JrDoctor> childDoctors { get; set;}
	}
	public class JrDoctor : Entity
	{
		public long? DoctorId { get; set;}
		[ForeignKey("DoctorId")]
		public virtual Doctor Doctor { get; set;}
		public long? JuniorDoctorId { get; set;}
		[ForeignKey("JuniorDoctorId")]
		public virtual Doctor JuniorDoctor { get; set;}
	}
