    public class MedicalInfo
    {
        public string MedicareNumber { get; set; }
        public DateTime PartAEffectiveDate { get; set; }
        public DateTime PartBEffectiveDate { get; set; }
    
        public List<Prescription> Prescriptions
        {
            get
            {
                return _prescritpions ?? (_prescritpions = GetDefaultPrescriptions());
            }
            set
            {
                _prescritpions = value;
            }
        }
        List<Prescription> _prescritpions;
    
        public MedicalInfo()
        {
            PartAEffectiveDate = new DateTime(1900, 01, 01);
            PartBEffectiveDate = new DateTime(1900, 01, 01);
        }
        static List<Prescription> GetDefaultPrescriptions()
        {
            return new List<Prescription> 
                   { 
                       new Prescription { Instructions = "Default Description" }     
                   };
        }
    }
