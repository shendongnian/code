    public class Option
    {
        public int OptionID { get; set; }
        [Display(Name = "Option Type")]
        public string OptionName { get; set; }
        [Display(Name = "Description in English")]
        public string DescriptionEN { get; set; }
        [Display(Name = "Description in German")]
        public string DescriptionDE { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int LsystemID { get; set; }
        public virtual ICollection<OptionValue> OptionValues { get; set; }
        public int TechnicalCharacteristicID { get; set; }
        public virtual TechnicalCharacteristic TechnicalCharacteristic { get; set; }
        public virtual Lsystem Lsystem { get; set; }
        // public virtual ICollection< SetValue> SetValue { get; set; }
        DateTime d = new DateTime();
    }
    public class TechnicalCharacteristic
    {
        public int TechnicalCharacteristicID { get; set; }
        [Display(Name = "Technical Characteristic Name")]
        public string TCName { get; set; }
        [Display(Name = "Description in English")]
        public string DescriptionEN { get; set; }
        [Display(Name = "Description in German")]
        public string DescriptionDE { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public virtual ICollection<TcSet> TcSets { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
