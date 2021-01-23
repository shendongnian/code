    public class MatchList : IEquatable<MatchList>
    {
        private readonly int someInt;
        private readonly decimal someDecimal;
        public MatchList(int myInt, decimal myDecimal)
        {
             this.someInt = myInt;
             this.myDecimal = myDecimal;
        }
        public int SomeInt { get { return this.someInt; } }
        public decimal SomeDecimal { get { return this.someDecimal; } }
  
        public bool Equals( MatchList other )
        {
          return (other != null) 
              && (this.SomeInt == other.SomeInt)
              && (this.SomeDecimal == other.SomeDecimal);
        }
        public override bool Equals( object obj )
        {
            return (obj is MatchList) && this.Equals(obj as MatchList);
        }
        public override int GetHashCode()
        { 
            return (this.SomeInt * 17) ^ this.SomeDecimal.GetHashCode();
        }
    }
