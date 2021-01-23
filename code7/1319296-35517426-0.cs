    public class JrDoctor : Entity
    {
        public long? DoctorId { get; set;}
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set;}
    
        public long? JuniorDoctorId { get; set;}
        [ForeignKey("JuniorDoctorId")]
        public virtual Doctor JuniorDoctor { get; set;}
    }
