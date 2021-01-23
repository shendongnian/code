    public class TestStylo
    {
        [Key]
        public int TestStyloID { get; set; }
        StyloType styloType { get; set; }
        public string name;
    
        public TestStylo(StyloType styloType, string name)
        {
            this.styloType = styloType;
            this.name = name;
        }
        public StyloType getTypeStylo{
            get { return styloType; }
        }
    
        // Add this:
        public TestStylo()
        {
        }
    }
