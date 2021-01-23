    public class RequiredPower
    {
        public int RequiredPowerID { get; set; }
        [Required(ErrorMessage = "This field cannot be empty!")]
        [MaxLength(25, ErrorMessage = "This name is too long. Max. 35 characters allowed!")]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        public int Position { get; set; }
        public virtual ICollection<PowerConnector> PowerConnectors { get; set; }
        public virtual ICollection<RequiredFuses> RequiredFuses { get; set; }
    }
