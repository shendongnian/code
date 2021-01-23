     public class HelperCode
    {
        
        public byte Level { get; set; }
        public byte CommissioningFlag { get; set; }
        public string LastChange { get; set; }
        public string CodeId { get; set; }
        public virtual Code Code { get; set; }
    }
      public class Code
    {
        public string Id { get; set; }
        public byte Level { get; set; }
        public virtual HelperCode HelperCode { get; set; }
    }
