    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DisplayAttribute : Attribute
    {
        public DisplayAttribute(string displayName)
        {
            Description = displayName;
        }
        public string Description { get; set; }
    }
    public enum SubsAmount
    {
        [Display("One Year")]
        Oneyear = 0,
        [Display("Two Years")]
        TwoYears = 1,
        [Display("Three Years")]
        ThreeYears = 2
    }
