    [Table("TypeData.StateProvince")]
    public class StateProvince : BaseSqlEntity, IStateProvince
    {
        [Required, MaxLength(3)]
        public string Abbreviation { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        ICountry IStateProvince.Country
        {
            get
            {
                return Country;
            }
            set
            {
                Country = (Country)value;
            }
        }
    }
