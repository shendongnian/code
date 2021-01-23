    public partial class Country
    {
        /* other properties */
        [ForeignKey("Code")]
        public IList<State> States { get; set; }
    }
    public partial class State
    {
        /* other properties */
        [ForeignKey("CountryCode")]
        public Country Country { get; set; }
    }
