    public class VisitContext
    {
        public VisitedType Visited { get; set; }
        public bool IsLeftNode { get; set; }
        public bool IsRightNode { get; set; }
        // this.
        public LinkedList<VisitedType> Lineage { get; set; }       
    }
