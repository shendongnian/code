    public class MyStuff : IComparable<MyStuff>
    {
        public int High { get; set; }
        public int Low { get; set; }
        public int TieBreaker { get; set; }
    
        public int CompareTo(MyStuff other)
        {
            // if an object's low is higher than another object's high, 
            // it appears before it in the list
            if ((this.Low > other.High) ||
                // if its high is between the other object's low and 
                // high then compare their tiebreaker
                (this.High > other.Low && this.High < other.High && 
                    this.TieBreaker > other.TieBreaker))
                return 1;
            else if (this.Low == other.High)
                return 0;
            else
                return -1;
        }
    }
