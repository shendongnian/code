    public class Option
    {
        public int OptionID { get; set;}
        public string OptionName { get; set; }
        public virtual ICollection<OptionValue> OptionValues { get; set; }
    }
    public class OptionValue
    {
        public int OptionValueID { get; set; }
        public string OptionVal { get; set; }
        public virtual Option Option { get; set; }
        public virtual ICollection< SetValue> SetValue { get; set; }
    }
