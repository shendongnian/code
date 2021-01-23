    namespace Models
    {
        [Serializable]
        public class Speciality
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int SpecialityId { get; set; }
    
            public string Name { get; set; }
    
            public virtual ICollection<Doctor> Doctors { get; set; }
            public virtual ICollection<MedicalFacility> MedicalFacilities { get; set; }
        }
    } 
