    public class Threshold
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public virtual int Calculate( int input )
        {
            // logic goes here
        }
    }
    public class AdvancedThreshold : Threshold
    {
        public int Extra { get; set; }
       
        public override int Calculate( int input )
        {
            // advanced logic goes here
        }
    }
