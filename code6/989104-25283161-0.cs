I re-created your Models but made some adjustments that generate the same results. I manually created the junction table VacationsCountries with the following code:
    public class VacationsCountries
    {
        [Key, Column(Order = 0)]
        public int VacationId { get; set; }
        public virtual Vacations Vacation { get; set; }
        [Key, Column(Order = 1)]
        public int CountryId { get; set; }
        public virtual Countries Country { get; set; }
    }
