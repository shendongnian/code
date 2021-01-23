    public class MatchList : IEquatable<MatchList>
    {
        public int SomeInt { get; set; }
        public decimal SomeDecimal { get; set; }
  
        public bool Equals( MatchList other )
        {
          return (this.SomeInt == other.SomeInt)
              && (this.SomeDecimal == other.SomeDecimal);
        }
        public override bool Equals( object obj )
        {
            return (obj is MatchList) && this.Equals(obj as MatchList);
        }
        public override int GetHashCode()
        { 
            return (this.SomeInt * 17) + this.SomeDecimal.GetHashCode();
        }
    }
