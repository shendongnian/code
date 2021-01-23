    public class Security
    {
        public int SecurityID {get;set;}
        //Other properties
        public int IncomeFrequencyID {get;set;}
    
        //Navigation Properties
        [ForeignKey("IncomeFrequencyID")]
        public virtual Frequency IncomeFrequency {get;set;}
    }
