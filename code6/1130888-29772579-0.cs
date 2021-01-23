    public class T19Model:ITModel
    {
        public T19Item[] Items { get; set; }
    
        public T19PeriodHead[] PeriodHeads { get; set; }
    
        ITPeriodHead[] ITModel.PeriodHeads 
        { 
            get {return PeriodHeads;}
            set {/* what to do here if value is not an array of T19PeriodHeads? */}
        }
    }
