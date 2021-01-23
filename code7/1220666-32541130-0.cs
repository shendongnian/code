    public class PreferencesInput
    {
        public IList<InterestArea> InterestAreas { get; set; }
        public bool SolicitationFlag { get; set; }
    }
    public class InterestArea
    {
        public string ShortName { get; set; }
        public string ShortNameDescription { get; set; }
        ...
    }
