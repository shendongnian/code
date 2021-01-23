    public class MatchList : IEquatable<MatchList>
    {
        // Note: Fields are readonly to satisfy GetHashCode contract
        private readonly int someInt;
        private readonly decimal someDecimal;
        // Public constructor creates immutable object
        public MatchList(int myInt, decimal myDecimal)
        {
             this.someInt = myInt;
             this.myDecimal = myDecimal;
        }
        // Properties are now read-only too.
        public int SomeInt { get { return this.someInt; } }
        public decimal SomeDecimal { get { return this.someDecimal; } }
  
        // Implementation of IEquatable<MatchList>
        public bool Equals( MatchList other )
        {
          return (other != null) 
              && (this.SomeInt == other.SomeInt)
              && (this.SomeDecimal == other.SomeDecimal);
        }
        // Override of Object.Equals
        // Calls the IEquatable.Equals version if possible.
        public override bool Equals( object obj )
        {
            return (obj is MatchList) && this.Equals(obj as MatchList);
        }
        public override int GetHashCode()
        { 
            return (this.someInt * 17) ^ this.someDecimal.GetHashCode();
        }
    }
