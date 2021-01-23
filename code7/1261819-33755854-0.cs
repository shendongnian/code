    [Table("TypeData.Country")]
    public class Country : BaseSqlEntity, ICountry
    {
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required]
        public string TwoLetterIsoCode { get; set; }
        [Required]
        public string ThreeLetterIsoCode { get; set; }
        public int NumericIsoCode { get; set; }
        public virtual List<StateProvince> StateProvinces { get; set; }
        List<IStateProvince> ICountry.StateProvinces
        {
            get
            {
                return StateProvinces.ToList<IStateProvince>();
            }
            set
            {
                StateProvinces = value.ToList().ConvertAll(o => (StateProvince)o);
            }
        }
    }
