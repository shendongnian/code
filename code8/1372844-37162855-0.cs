    public class CumulativeRecord
    {
        public int CumulativeRecordId { get; set; }
        public int AnaRecordId { get; set; }
        [ForeignKey("ANA")]
        public virtual ANA ANA { get; set; }
    }
    
    public class ANA
    {
        public int ANAId { get; set; }
        public virtual CumulativeRecord CumulativeRecord { get; set; }
    }
