    public class ABC
    {
        [Key, ForeignKey("A"), Column(order=0)]
        public int AId {get;set;}
        [Key, ForeignKey("B"), Column(order=1)]
        public int BId {get;set;}
        [Key, ForeignKey("C"), Column(order=2)]
        public int CId {get;set;}
    
        public virtual A A { get; set; }
        public virtual B B { get; set; }
        public virtual C C { get; set; }
    }
