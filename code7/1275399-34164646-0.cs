    public class MedicalInfo
    {
        public string MedicareNumber { get; set; }
        public DateTime PartAEffectiveDate { get; set; }
        public DateTime PartBEffectiveDate { get; set; }
    
        private List<Prescription> _prescritpions;
        public List<Prescription> Prescriptions
        {
            get
            {
                if (_prescritpions.Count == 0)
                {
                    _prescritpions.Add(new Prescription
                    {
                        Instructions = "Default Description"
                    });
                }
    
                return _prescritpions;
            }
            set
            {
                _prescritpions = value;
            }
        }
    
        public MedicalInfo()
        {
            PartAEffectiveDate = new DateTime(1900, 01, 01);
            PartBEffectiveDate = new DateTime(1900, 01, 01);
    
            _prescritpions = new List<Prescription>();
        }
    }
