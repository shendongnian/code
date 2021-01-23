    public partial class Country
    {
        /* other properties */
        public IList<State> States { get; set; }
    }
    public partial class State
    {
        /* other properties */
        [ForeignKey("CountryCode")]
        [InverseProperty("States")]
        public Country Country { get; set; }
    }
