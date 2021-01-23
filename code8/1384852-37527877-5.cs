    abstract class OwnedSegmentVisual<TOwner>: SegmentVisual where TOwner: Segment
    {
        public TOwner Owner { get; private set; }
    
        protected OwnedSegmentVisual(TOwner owner)
        {
            Owner = owner;
        }
    }
