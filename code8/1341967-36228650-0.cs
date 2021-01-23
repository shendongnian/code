    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YearRange : ValidationAttribute
    {
        private int m_min;
        private Range m_range;
    
        public PhoneMaskAttribute(int min)
        {
            m_min = min
            m_range = new Range(min, DateTime.Now.Year);
        }
    
    
        public override bool IsValid(object value)
        {
            return m_range.IsValid(value)
        }
    
        public override string FormatErrorMessage(string name)
        {
            return m_range.FormatErrorMessage(name);
        }
    }
