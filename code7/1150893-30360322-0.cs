    public class PO1Loop
    {
        public SegmentTypes.PO1LoopSegmentTypes.PO1 PO1 { get; set; }
        public Collection<SegmentTypes.PO1LoopSegmentTypes.PID1> PIDRepeat1 { get; private set; }
        public Collection<SegmentTypes.PO1LoopSegmentTypes.PID2> PIDRepeat2 { get; private set; }
        public SegmentTypes.PO1LoopSegmentTypes.PO4 PO4 { get; set; }
        /* Max Use: 8 */
        public Collection<SegmentTypes.PO1LoopSegmentTypes.ACK> ACKRepeat { get; private set; }
        public PO1Loop()
        {
            PIDRepeat1 = new Collection<SegmentTypes.PO1LoopSegmentTypes.PID1>();
            PIDRepeat2 = new Collection<SegmentTypes.PO1LoopSegmentTypes.PID2>();
            ACKRepeat = new Collection<SegmentTypes.PO1LoopSegmentTypes.ACK>();
        }
    }
